using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TasklistApp.Web.Hubs {
    public class TaskListHub : Hub {
        public void Hello() {
            Clients.All.hello();
        }
    }
}