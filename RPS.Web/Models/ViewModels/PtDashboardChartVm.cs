using RPS.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Web.Models.ViewModels
{
    public class PtDashboardChartVm
    {
        public PtDashboardFilteredIssues FilteredIssues { get; set; }

        public List<DateTime> Categories { get; set; }

        public List<int> ItemsOpenByMonth { get; set; }
        public List<int> ItemsClosedByMonth { get; set; }

        public PtDashboardChartVm(PtDashboardFilteredIssues filteredIssues)
        {
            FilteredIssues = filteredIssues;

            ItemsOpenByMonth = new List<int>();
            ItemsClosedByMonth = new List<int>();
            Categories = filteredIssues.Categories;

            filteredIssues.MonthItems.ForEach(i =>
            {
                ItemsOpenByMonth.Add(i.Open.Count);
                ItemsClosedByMonth.Add(i.Closed.Count);
            });
        }
    }
}
