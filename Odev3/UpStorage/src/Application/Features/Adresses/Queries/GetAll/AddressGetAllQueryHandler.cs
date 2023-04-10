using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adresses.Queries.GetAll
{
    public class AddressGetAllQueryHandler : IRequestHandler<AddressGetAllQuery, List<AddressGetAllDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressGetAllQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<AddressGetAllDto>> Handle(AddressGetAllQuery request, CancellationToken cancellationToken)
        {
         var dbQuery= _applicationDbContext.Addresses.AsQueryable();
            dbQuery=dbQuery.Where(x=>x.UserId==request.UserId);
            if(request.IsDeleted.HasValue ) dbQuery=dbQuery.Where(x=>x.IsDeleted==request.IsDeleted.Value);

            dbQuery = dbQuery.Include(x => x.Country);
            dbQuery = dbQuery.Include(x => x.City);

            var adresses = await dbQuery.ToListAsync(cancellationToken);

            var addressDtos = MapAddressesGetAllDtos(adresses);
            return addressDtos.ToList();
        }

        private IEnumerable<AddressGetAllDto> MapAddressesGetAllDtos(List<Address> adresses)
        {

            List<AddressGetAllDto> addressGetAllDtos = new List<AddressGetAllDto>();
            
            foreach (var address in adresses)
            {

                yield return new AddressGetAllDto()
                {
                    Id = address.Id,
                    CityId = address.CityId,
                    CountryId = address.CountryId,
                    PostCode = address.PostCode,
                    District = address.District,
                    Name = address.Name,
                    UserId = address.UserId,
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                    AddressType = address.AddressType,
                    IsDeleted= address.IsDeleted,
                    
                    



                };

            }
        }

    }
}
