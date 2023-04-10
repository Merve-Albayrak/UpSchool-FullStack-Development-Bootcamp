using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adresses.Commands.HardDelete
{
    public class AddressHardDeleteCommand:IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
}
