using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Domain.Enums;

namespace TaskListApp.Web.Areas.User.Models.EmployeesViewModels {
    public class TaslListEmployeeViewModel :EmployeeViewModel 
    {
        public EmployeeStatus Status { get; set; }
        public int TasksQty { get; set; }
    }
}