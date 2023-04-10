using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface ICreatedByEntity
    {
        //oluşturulan zaman
        DateTimeOffset CreatedOn { get; set; }
         string? CreatedByUserId { get; set; }
    }
}
