using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskListApp.Web.Areas.User.Models.EmployeesViewModels {
    public class EmployeeViewModel 
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DepartmentViewModel Department { get; set; }
        
    }


}