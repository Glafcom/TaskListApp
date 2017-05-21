using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Web.Areas.User.Models.ToDoTasksViewModels;

namespace TaskListApp.Web.Areas.User.Models.ToDoTasksViewModels
{
    public class ToDoTaskIndexViewModel
    {
        public IEnumerable<ToDoTaskViewModel> ActualOwnTasks { get; set; }
        public IEnumerable<ToDoTaskViewModel> ActualAssignedTasks { get; set; }
    }
}