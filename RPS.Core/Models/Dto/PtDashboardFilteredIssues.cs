using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Core.Models.Dto
{

    public class ItemsForMonth
    {
        public List<PtItem> Closed { get; set; }
        public List<PtItem> Open { get; set; }

        public ItemsForMonth()
        {
            Closed = new List<PtItem>();
            Open = new List<PtItem>();
        }
    }

    public class PtDashboardFilteredIssues
    {
        public List<DateTime> Categories { get; set; }
        public List<ItemsForMonth> MonthItems { get; set; }

        public PtDashboardFilteredIssues()
        {
            Categories = new List<DateTime>();
            MonthItems = new List<ItemsForMonth>();
        }
    }
}

