using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Domain.Filters;
using TaskListApp.Web.Areas.User.Models.EmployeesViewModels;

namespace TaskListApp.Web.Areas.User.Models.EmployeesViewModels {
    public class EmployeesViewModel 
    {
        public EmployeeFilter Filter { get; set; }
        public IEnumerable<TaskListEmployeeViewModel> Employees { get; set; }
        public DepartmentViewModel Department { get; set; }
        public bool IsLocalScope { get; set; }
    }

    public class DepartmentViewModel 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}