using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Contexts
{
    public class IdentityContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
//var configurationBuilder = new ConfigurationBuilder();
            
              
          optionsBuilder.UseMySql("Server=141.98.112.67;Port=7002;Database=merve_albayrak_upstorage;Uid=merve_albayrak;Pwd=hjBxdL3Mc3Z7LDxC3cG58AZVA;", serverVersion);
          //  optionsBuilder.app(Assembly.GetExecutingAssembly());



            return new IdentityContext(optionsBuilder.Options);
        }
    }
}
