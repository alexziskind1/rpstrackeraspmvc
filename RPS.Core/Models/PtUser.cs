using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPS.Core.Models
{
    public class PtUser : PtObjectBase
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
    }
}
