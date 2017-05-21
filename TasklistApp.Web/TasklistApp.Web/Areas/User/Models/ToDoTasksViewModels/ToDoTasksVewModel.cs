using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskListApp.Web.Areas.User.Models.ToDoTasksViewModels
{
    public class ToDoTasksVewModel
    {        
        public IEnumerable<ToDoTaskViewModel> ToDoTasks { get; set; }
    }
}