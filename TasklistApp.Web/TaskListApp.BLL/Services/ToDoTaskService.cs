using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Contracts.BLLContracts.Services;
using TaskListApp.Contracts.DALContracts;
using TaskListApp.Domain.Enums;
using TaskListApp.Domain.Models;

namespace TaskListApp.BLL.Services
{
    public class ToDoTaskService : BaseService<ToDoTask>, IToDoTaskService
    {
        public ToDoTaskService(IGenericRepository<ToDoTask> itemRepository)
            : base(itemRepository)
        {
        }

        public IEnumerable<ToDoTask> GetOwnToDoTasks(Guid userId)
        {
            return GetItems().Where(t => t.AuthorId == userId);
        }

        public IEnumerable<ToDoTask> GetActualOwnToDoTasks(Guid userId)
        {
            var date = DateTime.Today;
            return GetActualOwnToDoTasks(userId, date);
        }

        public IEnumerable<ToDoTask> GetActualOwnToDoTasks(Guid userId, DateTime date)
        {
            return GetOwnToDoTasks(userId).Where(t =>
                        t.Status != ToDoTaskStatus.Done
                        && t.CreateDate <= date
                        && (t.StartDate.HasValue ? date >= t.StartDate : true)
                        && (t.FinishDate.HasValue ? date <= t.FinishDate : true));
        }

        public ToDoTask GetOwnToDoTask(Guid userId, Guid taskId)
        {
            return GetOwnToDoTasks(userId).Where(t => t.Id == taskId).FirstOrDefault();
        }

        public IEnumerable<ToDoTask> GetAssignedToDoTasks(Guid userId)
        {
            return GetItems().Where(t => t.AssigneeId == userId);
        }

        public IEnumerable<ToDoTask> GetActualAssignedToDoTasks(Guid userId)
        {
            var date = DateTime.Today;
            return GetActualAssignedToDoTasks(userId, date);
        }
        public IEnumerable<ToDoTask> GetActualAssignedToDoTasks(Guid userId, DateTime date)
        {
            return GetAssignedToDoTasks(userId).Where(t =>
                        t.Status != ToDoTaskStatus.Done
                        && t.CreateDate <= date
                        && (t.StartDate.HasValue ? date >= t.StartDate : true)
                        && (t.FinishDate.HasValue ? date <= t.FinishDate : true));
        }

        public ToDoTask GetAssignedToDoTask(Guid userId, Guid taskId)
        {
            return GetAssignedToDoTasks(userId).Where(t => t.Id == taskId).FirstOrDefault();
        }

        public void RejectToDoTask(Guid toDoTaskId, string info)
        {
            var toDoTask = GetItem(toDoTaskId);
            toDoTask.Status = ToDoTaskStatus.Rejected;
            toDoTask.Information = info;
            ChangeItem(toDoTaskId, toDoTask);
        }

        public void CompliteToDoTask(Guid toDoTaskId, string info)
        {
            var toDoTask = GetItem(toDoTaskId);
            toDoTask.Status = ToDoTaskStatus.Done;
            toDoTask.Information = info;
            ChangeItem(toDoTaskId, toDoTask);
        }

        public void StopToDoTaskExecuting(Guid toDoTaskId)
        {
            var toDoTask = GetItem(toDoTaskId);
            toDoTask.Status = ToDoTaskStatus.Paused;
            toDoTask.Information = string.Empty;
            ChangeItem(toDoTaskId, toDoTask);
        }

        public void StartToDoTaskExecuting(Guid toDoTaskId)
        {
            var toDoTask = GetItem(toDoTaskId);
            toDoTask.Status = ToDoTaskStatus.InProgress;
            toDoTask.Information = string.Empty;
            ChangeItem(toDoTaskId, toDoTask);
        }
    }
}
