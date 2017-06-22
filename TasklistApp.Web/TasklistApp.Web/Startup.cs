using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(TaskListApp.Web.Startup))]
namespace TaskListApp.Web 
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}