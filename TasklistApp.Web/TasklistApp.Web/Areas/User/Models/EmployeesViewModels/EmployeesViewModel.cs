using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Domain.Filters;


namespace TaskListApp.Web.Areas.User.Models.EmployeesViewModels {
    public class EmployeesViewModel 
    {
        public EmployeeFilter Filter { get; set; }
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
        
    }

    public class Department 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}