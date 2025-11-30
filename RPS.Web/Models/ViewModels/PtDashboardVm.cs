using RPS.Core.Models;
using RPS.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPS.Web.Models.ViewModels
{
    public class PtDashboardVm
    {
        public DateTime? DateStart { get; set;}
        public DateTime? DateEnd { get; set; }

        public PtDashboardStatusCounts StatusCounts { get; set; }

        public PtDashboardFilteredIssues FilteredIssues { get; set; }

        public int? SelectedAssigneeId { get; set; }
        public List<PtUser> Assignees { get; set; }

        public PtDashboardVm(PtDashboardStatusCounts statusCounts, 
            PtDashboardFilteredIssues filteredIssues,
            List<PtUser> users,
            int? userId)
        {
            StatusCounts = statusCounts;
            FilteredIssues = filteredIssues;

            Assignees = users;
            if (userId.HasValue)
            {
                SelectedAssigneeId = userId;
            }
            
        }
    }
}