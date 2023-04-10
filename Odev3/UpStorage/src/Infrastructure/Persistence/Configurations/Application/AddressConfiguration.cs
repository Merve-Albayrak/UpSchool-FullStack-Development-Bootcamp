using Domain.Entities;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
       

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AddressType).HasConversion<int>();
            //builder.
            builder.HasOne<User>().WithMany(x=>x.Adresses)
                 .HasForeignKey(x => x.UserId);
            builder.HasOne<City>().WithMany(x => x.Adresses)
                .HasForeignKey(x => x.CityId);
                ;
            builder.HasOne<Country>().WithMany(x=>x.Adresses)
                
                .HasForeignKey(x=>x.CountryId);  
            builder.ToTable("Adresses");

            
        }
    }
}
