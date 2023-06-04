
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices


    {
        //bu class neden statik
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string wwwrootPath  )
        {


            //    var connectionString = configuration.GetConnectionString("MariaDB");

            services.AddSingleton<IEmailService>(new EmailManager(wwwrootPath));
            return services;
        }


    }

}
