using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskListApp.Web.Areas.User.Models.ToDoTasksViewModels
{
    public class ToDoTasksViewModel
    {        
        public IEnumerable<ToDoTaskViewModel> ToDoTasks { get; set; }
    }
}