using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPS.Core.Models.Enums
{
    public enum StatusEnum
    {
        Submitted = 2,
        Open = 4,
        Closed = 8,
        ReOpened = 16
    }
}
