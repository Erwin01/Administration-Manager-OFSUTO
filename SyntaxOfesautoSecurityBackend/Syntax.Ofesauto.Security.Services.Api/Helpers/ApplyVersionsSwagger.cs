using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Syntax.Ofesauto.Security.Services.Api.Helpers
{

    public class ApplyVersionsSwagger : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext operationFilterContext)
        {
            if (operation.Parameters.Count > 0)
            {
                //var versionParameter = operation.Parameters.Single(p => p.Name == "version");
                //operation.Parameters.Remove(versionParameter);
            }
        }
    }


    public class ReplaceVersionWithExactValueInPath : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext documentFilterContext)
        {
            var paths = swaggerDoc.Paths;
            swaggerDoc.Paths = new OpenApiPaths();

            foreach (var path in paths)
            {
                var key = path.Key.Replace("v{version}", swaggerDoc.Info.Version);
                var value = path.Value;
                swaggerDoc.Paths.Add(key, value);
            }
        }
    }
}

