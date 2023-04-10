using Application.Common.Interfaces;

using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adresses.Commands
{
    public class AddressAddCommandHandler:IRequestHandler<AddressAddCommand,Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public AddressAddCommandHandler(IApplicationDbContext applicationDbContext)
        
        
        {
        _applicationDbContext = applicationDbContext;
        
        }

        public async Task<Response<Guid>> Handle(AddressAddCommand request, CancellationToken cancellationToken)
        {
            var address = new Address()
            {


                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                District = request.District,
                AddressType = request.AddressType,
                CityId = request.CityId,
                CountryId = request.CountryId,
                CreatedByUserId = null,
                PostCode = request.PostCode,
                Name = request.Name,
                CreatedOn = DateTimeOffset.Now,
                UserId = request.UserId,
                IsDeleted=false


            };

            await _applicationDbContext.Addresses.AddAsync(address,cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>($" The address name \"{address.Name} \" was successfully saved", address.Id);
            
        }
    }
}
