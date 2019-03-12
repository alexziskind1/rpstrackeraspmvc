using Newtonsoft.Json;
using RPS.Core.Models;
using RPS.Core.Models.Enums;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;

namespace RPS.Data
{
    public class InMemoryRpsDataPtItems : IRpsDataPtItems
    {
        string resourceNameItems = "RPS.Data.GenData.fs-items.json";

        List<PtItem> items;

        public InMemoryRpsDataPtItems()
        {
            var assembly = Assembly.GetExecutingAssembly();

            string contentsItems = "[]";

            using (Stream stream = assembly.GetManifestResourceStream(resourceNameItems))
            using (StreamReader file = new StreamReader(stream))
            {
                contentsItems = file.ReadToEnd();
            }

            items = JsonConvert.DeserializeObject<List<PtItem>>(contentsItems);
        }

        public IEnumerable<PtItem> GetAll()
        {
            return items;
        }

        public IEnumerable<PtItem> GetClosedItems()
        {
            return items.Where(i => i.Status == StatusEnum.Closed && 
            i.DateDeleted == null);
        }

        public PtItem GetItemById(int itemId)
        {
            return items.SingleOrDefault(i => i.Id == itemId);
        }

        public IEnumerable<PtItem> GetOpenItems()
        {
            return items.Where(i => (i.Status == StatusEnum.Open ||
                                      i.Status == StatusEnum.ReOpened) &&
                                        i.DateDeleted == null);
        }

        public IEnumerable<PtItem> GetUserItems(int userId)
        {
            return items.Where(i => i.Assignee.Id == userId &&
                                    i.DateDeleted == null);
        }
    }
}
