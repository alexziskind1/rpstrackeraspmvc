using RPS.Core.Models;
using RPS.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Data
{
    public interface IPtTasksRepository
    {
        IEnumerable<PtTask> GetAllForItem(int itemId);

        PtTask AddNewTask(PtNewTask newTask);
        PtTask UpdateTask(PtUpdateTask updateTask);
        bool DeleteTask(int id, int itemId);
    }
}
