using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContextFactory:IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            //var configurationBuilder = new ConfigurationBuilder();
        //    var conStrBuilder = new MySqlConnectionStringBuilder(
        //conStrBuilder.ConnectionString.GetConnectionString("Movies"));
        //    conStrBuilder.Password = builder.Configuration["DbPassword"];
           // var connection = conStrBuilder.ConnectionString;

            optionsBuilder.UseMySql("Server=141.98.112.67;Port=7002;Database=merve_albayrak_upstorage;Uid=merve_albayrak;Pwd=hjBxdL3Mc3Z7LDxC3cG58AZVA;", serverVersion);
            //  optionsBuilder.app(Assembly.GetExecutingAssembly());



            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
