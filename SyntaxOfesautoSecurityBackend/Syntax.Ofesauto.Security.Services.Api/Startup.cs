using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Syntax.Ofesauto.Security.Application.Interface;
using Syntax.Ofesauto.Security.Application.Main;
using Syntax.Ofesauto.Security.Domain.Core;
using Syntax.Ofesauto.Security.Domain.Interface;
using Syntax.Ofesauto.Security.Infraestructure.Data;
using Syntax.Ofesauto.Security.Infraestructure.Interface;
using Syntax.Ofesauto.Security.Infraestructure.Repository;
using Syntax.Ofesauto.Security.Services.Api.Email;
using Syntax.Ofesauto.Security.Services.Api.Helpers;
using Syntax.Ofesauto.Security.Transversal.Common;
using Syntax.Ofesauto.Security.Transversal.Logging;
using Syntax.Ofesauto.Security.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Services.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            // Others services
            #region [ OTHERS SERVICES ]
            services.AddControllers();
            #endregion


            // Auto mapper configurations
            #region [ AUTO MAPPER ]
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion


            // Dependences injection
            #region [ DEPENDENCES INJECTION ]
            var appSettingsSection = Configuration.GetSection("Config");

            services.Configure<AppSettings>(appSettingsSection);

            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<CustomDataContext>(c => c.UseSqlServer(Configuration.GetConnectionString("Ofesauto")));
            services.AddScoped<IUserDomainEF, UserDomainEF>();
            services.AddScoped<IUserApplicationEF, UserApplicationEF>();
            services.AddScoped<IUserTypeDomainEF, UserTypeDomainEF>();
            services.AddScoped<IUserTypeApplicationEF, UserTypeApplicationEF>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            #endregion


            // Configuration service E-mail
            #region [ CONFIGURATION E-MAIL ]
            var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            #endregion


            //Register the Swagger generator, defining 1 or more Swagger documents
            #region [ SWAGGER DOCUMENTATION MANAGER ]
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Syntax Ofesauto Api - Security",
                    Version = "v1",
                    Description = "OFICINA ESPAÑOLA DE ASEGURADORAS DE AUTOMOVIL",
                    TermsOfService = new Uri("https://www.ofesauto.es/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Syntax Group",
                        Email = "info@syntax.es",
                        Url = new Uri("https://www.syntax.es/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Syntax Group",
                        Url = new Uri("https://www.syntax.es/soluciones/")
                    }

                });


                c.ResolveConflictingActions(a => a.First());
              


                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = ConfigurationPath.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlFile);

            });
            #endregion


            //Services of authentication using Jason Web Token
            #region [ AUTHENTICATION JWT ]
            var appsetings = appSettingsSection.Get<AppSettings>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //Events in token
            .AddJwtBearer(x =>
            {
             
           
                //x.Events = new JwtBearerEvents
                //{
                //    OnTokenValidated = context =>
                //    {
                //        var userId = int.Parse(context.Principal.Identity.Name);
                //        return Task.CompletedTask;
                //    },
                //    //Exception in the moment of authentication
                //    OnAuthenticationFailed = context =>
                //    {
                //        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                //        {
                //            context.Response.Headers.Add("Token-Expired", "true");

                //        }

                //        return Task.CompletedTask;
                //    },
                //};
                var key = Encoding.ASCII.GetBytes(Configuration["Config:Secret"]);
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                //Validation of token
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = false
                };
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }

            #region [ CORS ]
            app.UseCors(options =>
            {

                options.WithOrigins("http://localhost:3000", "http://claim-manager.ofesauto.es", "http://admin-manager.ofesauto.es", "http://incidents.ofesauto.es");
                options.AllowAnyMethod();
                options.AllowAnyHeader();

            });
            #endregion
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Syntax.Ofesauto.Security.Services.Api v1"));
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
