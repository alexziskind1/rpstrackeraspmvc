using RPS.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace RPS.Data
{
    public interface IRpsDataPtUsers
    {
        IEnumerable<PtUser> GetAll();
    }
}
