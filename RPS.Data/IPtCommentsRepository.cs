using RPS.Core.Models;
using RPS.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Data
{
    public interface IPtCommentsRepository
    {
        IEnumerable<PtComment> GetAllForItem(int itemId);
        PtComment AddNewComment(PtNewComment newComment);
    }
}
