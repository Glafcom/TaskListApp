using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Web.Areas.User.Models.ToDoTasksViewModels;

namespace TaskListApp.Web.Areas.User.Models.EmployeesViewModels {
    public class EmployeeTasksViewModel 
    {
        public EmployeeViewModel Employee { get; set; }
        public IEnumerable<ToDoTaskViewModel> Tasks { get; set; }
    }
}