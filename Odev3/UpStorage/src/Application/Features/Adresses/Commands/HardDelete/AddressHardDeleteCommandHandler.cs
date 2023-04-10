using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adresses.Commands.HardDelete
{
    public class AddressHardDeleteCommandHandler : IRequestHandler<AddressHardDeleteCommand, Response<Guid>>
    {

        private readonly IApplicationDbContext _applicationDbContext;

        public AddressHardDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

       
    public async Task<Response<Guid>> Handle(AddressHardDeleteCommand request, CancellationToken cancellationToken)
        {
            var address = await _applicationDbContext.Addresses.Where(x=>x.Id==request.Id).FirstOrDefaultAsync();
            if (address == null)
            {

                throw new ArgumentException(nameof(request.Id));
            }

            else
            {
                _applicationDbContext.Addresses.Remove(address);

            }
           
            return new Response<Guid>($"address \"{address.Name}\" has been successfully removed");
        }
    }
}
