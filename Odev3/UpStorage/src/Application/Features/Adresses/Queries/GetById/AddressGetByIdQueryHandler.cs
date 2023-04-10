using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adresses.Queries.GetById
{
    public class AddressGetByIdQueryHandler : IRequestHandler<AddressGetByIdQuery, AddressGetByIdDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public AddressGetByIdQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<AddressGetByIdDto> Handle(AddressGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _applicationDbContext.Addresses.AsQueryable();
             dbQuery=  dbQuery.Where(x=>x.Id==request.Id);
         
            var address= await dbQuery.FirstOrDefaultAsync(cancellationToken);


            var addressDto = MapAddressToGetByIdDto(address);
            return addressDto;

        }

        private AddressGetByIdDto MapAddressToGetByIdDto(Address? address)
        {
           AddressGetByIdDto addressDto = new AddressGetByIdDto();

            return new AddressGetByIdDto()
            {

               // Id = address.Id,
                CityId = address.CityId,
                CountryId = address.CountryId,
                PostCode = address.PostCode,
                District = address.District,
                Name = address.Name,
                UserId = address.UserId,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                AddressType = address.AddressType,
                IsDeleted = address.IsDeleted,


            };
        }
    }
}
