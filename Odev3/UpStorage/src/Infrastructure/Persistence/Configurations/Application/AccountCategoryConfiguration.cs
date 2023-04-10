using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class AccountCategoryConfiguration : IEntityTypeConfiguration<AccountCategory>
    {
        //çoka çok ilişkilerde configler ortak tabloda yapılır
        public void Configure(EntityTypeBuilder<AccountCategory> builder)
        {

            //id
            builder.HasKey(x => new { x.AccountId, x.CategoryId });

            //relationships


            builder.HasOne<Account>(x => x.Account)
                .WithMany(x => x.AccountCategories)
                .HasForeignKey(x => x.AccountId);

            builder.HasOne<Category>(x => x.Category)
                .WithMany(x => x.AccountCategories)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
