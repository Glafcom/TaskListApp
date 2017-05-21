﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Domain.Models;

namespace TaskListApp.Contracts.BLLContracts.Domains
{
    public interface IUserDomain
    {
        IEnumerable<ToDoTask> GetOwnToDoTasks();
        IEnumerable<ToDoTask> GetActualOwnToDoTasks();
        ToDoTask GetOwnToDoTask(Guid toDoTaskId);

        ToDoTask GetToDoTask(Guid toDoTaskId);
        void CreateToDoTask(ToDoTask toDoTask);
        void EditToDoTask(ToDoTask toDoTask);
        void DeleteToDoTask(Guid toDoTaskId);
        IEnumerable<ToDoTask> GetAssignedToDoTasks();
        IEnumerable<ToDoTask> GetActualAssignedToDoTasks();
        ToDoTask GetAssignedToDoTask(Guid toDoTaskId);
        void RejectToDoTask(Guid toDoTaskId, string info);
        void CompliteToDoTask(Guid toDoTaskId, string info);
        void StopToDoTaskExecuting(Guid toDoTaskId);
        void StartToDoTaskExecuting(Guid toDoTaskId);
    }
}