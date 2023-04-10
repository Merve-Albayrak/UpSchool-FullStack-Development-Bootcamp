using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adresses.Queries.GetById
{
    public class AddressGetByIdQuery:IRequest<AddressGetByIdDto>
    {

        public Guid Id { get; set; }
        public AddressGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
