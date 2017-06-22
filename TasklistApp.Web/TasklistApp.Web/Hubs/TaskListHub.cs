using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using TaskListApp.Domain.Models.Identity;
using TaskListApp.Contracts.DtoModels;
using System.Threading.Tasks;
using TaskListApp.Domain.Models;
using Newtonsoft.Json;
using TaskListApp.Contracts.BLLContracts.Services;
using TaskListApp.Domain.Enums;
using TaskListApp.Contracts.WebContracts;

namespace TasklistApp.Web.Hubs {
    public class TaskListHub : Hub, ITaskListHub 
    {
        static List<ConnectedUser> Users = new List<ConnectedUser>();

        //Connecting of user
        public void Connect(string userName) 
        {
            var id = Context.ConnectionId;
            
            if (!Users.Any(u => u.ConnectionId == id)) 
            {
                Users.Add(new ConnectedUser { ConnectionId = id, UserName = userName });

                Clients.Caller.onConnected(id, userName, Users);

                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }

        public override Task OnDisconnected(bool stopCalled) 
        {
            var id = Context.ConnectionId;

            var item = Users.FirstOrDefault(u => u.ConnectionId == id);
            if (item != null) 
            {
                Users.Remove(item);
                Clients.All.onUserDisconnected(id, item.UserName);
            }

            return base.OnDisconnected(stopCalled);
        }

        public void CreateToDoTask(ToDoTask task) {
            var assignee = Users.FirstOrDefault(u => u.UserName == task.Assignee.UserName);
            Clients.Client(assignee.ConnectionId).onTaskCreated(JsonConvert.SerializeObject(task));
        }

        public void EditToDoTask(ToDoTask task) {
            var assignee = Users.FirstOrDefault(u => u.UserName == task.Assignee.UserName);
            Clients.Client(assignee.ConnectionId).onTaskEdited(JsonConvert.SerializeObject(task));
        }

        public void DeleteToDoTask(Guid taskId, string userName) {
            var assignee = Users.FirstOrDefault(u => u.UserName == userName);
            Clients.Client(assignee.ConnectionId).onTaskDelited(taskId);
        }

        public void ChangeToDoTaskStatus(Guid taskId, ToDoTaskStatus status, string info, string userName) {
            var assignee = Users.FirstOrDefault(u => u.UserName == userName);
            Clients.Client(assignee.ConnectionId).onTaskStatusChanged(taskId, status, info); 
        }

    }

    public class ConnectedUser {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
    }
}