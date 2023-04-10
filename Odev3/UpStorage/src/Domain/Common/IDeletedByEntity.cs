﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IDeletedByEntity
    {
        DateTimeOffset? DeletedOn { get; set; }
         string? DeletedByUserId { get; set; }
       bool IsDeleted { get; set; }
    }
}
