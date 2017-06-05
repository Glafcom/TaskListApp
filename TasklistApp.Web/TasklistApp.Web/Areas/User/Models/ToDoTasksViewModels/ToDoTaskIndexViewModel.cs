using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Domain.Enums;
using TaskListApp.Web.Areas.User.Models.EmployeesViewModels;

namespace TaskListApp.Web.Areas.User.Models.ToDoTasksViewModels
{
    public class ToDoTaskIndexViewModel
    {
        public IEnumerable<ToDoTaskViewModel> ActualOwnTasks { get; set; }
        public IEnumerable<ToDoTaskViewModel> ActualAssignedTasks { get; set; }

        public IEnumerable<TaskListEmployeeViewModel> ActiveEmployees { get; set; }
        public IEnumerable<TaskListEmployeeViewModel> AllEmployees { get; set; }
    }

    
}