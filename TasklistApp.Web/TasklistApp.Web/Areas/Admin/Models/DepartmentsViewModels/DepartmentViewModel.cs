using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskListApp.Web.Areas.Admin.Models.DepartmentsViewModels
{
    public class DepartmentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<EmployeeViewModel> Personal { get; set; }

    }

    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}