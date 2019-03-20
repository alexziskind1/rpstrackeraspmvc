using Newtonsoft.Json;
using RPS.Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace RPS.Data
{
    public class RpsPtUserRepository : IRpsPtUserRepository
    {

        private RpsInMemoryContext context;

        public RpsPtUserRepository(RpsInMemoryContext context)
        {
            this.context = context;
        }




        public IEnumerable<PtUser> GetAll()
        {
            return context.PtUsers;
        }
    }
}
