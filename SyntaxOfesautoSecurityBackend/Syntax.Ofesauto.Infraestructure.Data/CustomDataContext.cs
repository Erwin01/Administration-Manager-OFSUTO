using Microsoft.EntityFrameworkCore;
using Syntax.Ofesauto.Security.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syntax.Ofesauto.Security.Infraestructure.Data
{
    public class CustomDataContext : DbContext
    {
        public CustomDataContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
    }
}
