using RPS.Core.Models;
using RPS.Core.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace RPS.Data
{
    public interface IRpsDataPtItems
    {
        IEnumerable<PtItem> GetAll();
        IEnumerable<PtItem> GetUserItems(int userId);
        IEnumerable<PtItem> GetOpenItems();
        IEnumerable<PtItem> GetClosedItems();
        PtItem GetItemById(int itemId);
    }
}
