using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPS.Core.Models;
using RPS.Core.Models.Dto;
using RPS.Core.Models.Enums;
using RPS.Data.Helpers;

namespace RPS.Data
{
    public class PtDashboardRepository : IPtDashboardRepository
    {
        private PtInMemoryContext context;

        public PtDashboardRepository(PtInMemoryContext context)
        {
            this.context = context;
        }

        public PtDashboardFilteredIssues GetFilteredIssues(PtDashboardFilter filter)
        {
            var openItemSpec = new PtItemStatusSpecification(StatusEnum.Open).And(new PtItemStatusSpecification(StatusEnum.ReOpened));
            var closedItemSpec = new PtItemStatusSpecification(StatusEnum.Closed);

            var userIdSpec = new PtItemUserIdSpecification(filter.UserId);
            var dateRangeSpec = new PtItemDateRangeSpecification(filter.DateStart, filter.DateEnd);

            var openItems = Find(openItemSpec);

            var items = Find(userIdSpec.And(dateRangeSpec));

            var minDate = items.Min(i => i.DateCreated);
            var maxDate = items.Max(i => i.DateCreated);

            var categories = GetDates(minDate, maxDate);

            var itemsByMonth = categories.Select(c => {
                return items.Where(i => {
                    var dc = i.DateCreated;
                    return dc.Month == c.Month && dc.Year == c.Year;
                });
            });


            var categorizedAndDivided = itemsByMonth.Select(c => {
                var openItemsForMonth = c.AsQueryable().Where(openItemSpec.ToExpression()).ToList();
                var closedItemsForMonth = c.AsQueryable().Where(closedItemSpec.ToExpression()).ToList();

                return new ItemsForMonth
                {
                    Open = openItemsForMonth,
                    Closed = closedItemsForMonth
                };
            });

            var issues = new PtDashboardFilteredIssues
            {
                Categories = categories,
                MonthItems = categorizedAndDivided.ToList()
            };

            return issues;
        }


        public PtDashboardStatusCounts GetStatusCounts(PtDashboardFilter filter)
        {
            throw new NotImplementedException();
        }


        private IReadOnlyList<PtItem> Find(Specification<PtItem> specification)
        {
            return context.PtItems.AsQueryable().Where(specification.ToExpression()).ToList();
        }

        private List<DateTime> GetDates(DateTime min, DateTime max)
        {
            List<DateTime> months = new List<DateTime>();
            while (min <= max)
            {
                months.Add(new DateTime(min.Year, min.Month, 1));
                min = min.AddMonths(1);
            }
            return months;
        }

    }
}

