
using Domain.Entities;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    public class IdentityContext:IdentityDbContext<User,Role,string,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //assemly dosyasında okur
            //ignores 
            //contextler farklı olmasına rağmen identity objelerini dikkate almasın diye ignores yapıyoruz
            modelBuilder.Ignore<Account>();
            modelBuilder.Ignore<Country>();
            modelBuilder.Ignore<City>();
           modelBuilder.Ignore<AccountCategory>();
            modelBuilder.Ignore<Category>();
            modelBuilder.Ignore<Address>();
            base.OnModelCreating(modelBuilder);
        }
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }
    }
}
