using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adresses.Commands.Delete
{
    public class AddressDeleteCommandHandler : IRequestHandler<AddressDeleteCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response<Guid>> Handle(AddressDeleteCommand request, CancellationToken cancellationToken)
        {
            var address= await _applicationDbContext.Addresses.Where(x=>x.Id==request.Id).FirstOrDefaultAsync();

            if (address == null)
            {


                throw new ArgumentException(nameof(request.Id));
            }
            else
            {

                address.IsDeleted = true;
                address.DeletedOn = DateTimeOffset.Now;
                address.DeletedByUserId = null;
                address.ModifiedByUserId = null;
                address.ModifiedOn = DateTimeOffset.Now; 

                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return new Response<Guid>($"The address \"{address.Name}\" was successfully  deleted", address.Id);
            }

        }
    }
}
