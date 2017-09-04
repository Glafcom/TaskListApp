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
using Microsoft.AspNet.SignalR.Hubs;

namespace TasklistApp.Web.Hubs {
    public class TaskListHub : Hub
    {
        static List<ConnectedUser> Users = new List<ConnectedUser>();
        
        //Connecting of user
        public static void Connect(string connectionId, string userName) 
        {

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TaskListHub>();
            
            if (!Users.Any(u => u.UserName == userName)) {
                Users.Add(new ConnectedUser { ConnectionId = connectionId, UserName = userName });
                hubContext.Clients.AllExcept(connectionId).updateActiveUsers(Users.Select(u => u.UserName));
            }
        }

        public override Task OnDisconnected(bool stopCalled) 
        {
            var id = Context.ConnectionId;

            var item = Users.FirstOrDefault(u => u.ConnectionId == id);
            if (item != null) 
            {
                Users.Remove(item);
            }

            return base.OnDisconnected(stopCalled);
        }

        public static void CreateToDoTask(ToDoTask task) {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TaskListHub>();
            var assignee = Users.FirstOrDefault(u => u.UserName == task.Assignee.UserName);
            hubContext.Clients.Client(assignee.ConnectionId).onTaskCreated(JsonConvert.SerializeObject(task));
        }

        public static void EditToDoTask(ToDoTask task) {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TaskListHub>();
            var assignee = Users.FirstOrDefault(u => u.UserName == task.Assignee.UserName);
            hubContext.Clients.Client(assignee.ConnectionId).onTaskEdited(JsonConvert.SerializeObject(task));
        }

        public static void DeleteToDoTask(Guid taskId, string userName) {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TaskListHub>();
            var assignee = Users.FirstOrDefault(u => u.UserName == userName);
            hubContext.Clients.Client(assignee.ConnectionId).onTaskDelited(taskId);
        }

        public static void ChangeToDoTaskStatus(Guid taskId, ToDoTaskStatus status, string info, string userName) {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TaskListHub>();
            var assignee = Users.FirstOrDefault(u => u.UserName == userName);
            hubContext.Clients.Client(assignee.ConnectionId).onTaskStatusChanged(taskId, status, info); 
        }
    }

    public class ConnectedUser {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
    }
}