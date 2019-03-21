using RPS.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Data
{
    public interface IPtDashboardRepository
    {
        PtDashboardStatusCounts GetStatusCounts(PtDashboardFilter filter);
        PtDashboardFilteredIssues GetFilteredIssues(PtDashboardFilter filter);

    }
}
