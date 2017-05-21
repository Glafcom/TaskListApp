using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Domain.Models;

namespace TaskListApp.Contracts.BLLContracts.Services
{
    public interface IToDoTaskService : IBaseService<ToDoTask>
    {
        IEnumerable<ToDoTask> GetOwnToDoTasks(Guid userId);
        IEnumerable<ToDoTask> GetActualOwnToDoTasks(Guid userId);
        IEnumerable<ToDoTask> GetActualOwnToDoTasks(Guid userId, DateTime date);
        ToDoTask GetOwnToDoTask(Guid userId, Guid taskId); 
        IEnumerable<ToDoTask> GetAssignedToDoTasks(Guid userId);
        IEnumerable<ToDoTask> GetActualAssignedToDoTasks(Guid userId);
        IEnumerable<ToDoTask> GetActualAssignedToDoTasks(Guid userId, DateTime date);
        ToDoTask GetAssignedToDoTask(Guid userId, Guid taskId);
        void RejectToDoTask(Guid toDoTaskId, string info);
        void CompliteToDoTask(Guid toDoTaskId, string info);
        void StopToDoTaskExecuting(Guid toDoTaskId);
        void StartToDoTaskExecuting(Guid toDoTaskId);
    }
}
