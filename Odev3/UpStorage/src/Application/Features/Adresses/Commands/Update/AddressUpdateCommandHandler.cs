using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adresses.Commands.Update
{
    public class AddressUpdateCommandHandler : IRequestHandler<AddressUpdateCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressUpdateCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<Guid>> Handle(AddressUpdateCommand request, CancellationToken cancellationToken)
        {
            var address = await _applicationDbContext.Addresses.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (address == null)
            {

                throw new ArgumentException(nameof(request.Name));
            }
            else
            {
                address.AddressLine1 = request.AddressLine1;
                address.AddressLine2 = request.AddressLine2;
                address.Name = request.Name;
                address.District = request.District;
                address.PostCode = request.PostCode;


            }

            _applicationDbContext.Addresses.Update(address);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>($"The address was successfully update");
        }
    }
}
