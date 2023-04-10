using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adresses.Commands
{
    public class AddressAddCommand:IRequest<Response<Guid>>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int CountryId { get; set; }

        [Required]
        public int CityId { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }

        public AddressType AddressType { get; set; }
    }
}
