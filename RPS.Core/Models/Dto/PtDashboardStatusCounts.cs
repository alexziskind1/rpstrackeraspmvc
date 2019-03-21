using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Core.Models.Dto
{
    public class PtDashboardStatusCounts
    {
        public int ActiveItemsCount { get; set; }
        public int ClosedItemsCount { get; set; }
        public int OpenItemsCount { get; set; }
    }
}
