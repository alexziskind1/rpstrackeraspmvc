using Newtonsoft.Json;
using RPS.Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace RPS.Data
{
    public class InMemoryRpsDataPtUsers : IRpsDataPtUsers
    {
        string resourceNameUsers = "RPS.Data.GenData.fs-users.json";

        List<PtUser> users;

        public InMemoryRpsDataPtUsers()
        {
            var assembly = Assembly.GetExecutingAssembly();

            string contentsUsers = "[]";

            using (Stream stream = assembly.GetManifestResourceStream(resourceNameUsers))
            using (StreamReader file = new StreamReader(stream))
            {
                contentsUsers = file.ReadToEnd();
            }

            users = JsonConvert.DeserializeObject<List<PtUser>>(contentsUsers);
        }

        public IEnumerable<PtUser> GetAll()
        {
            return users;
        }
    }
}
