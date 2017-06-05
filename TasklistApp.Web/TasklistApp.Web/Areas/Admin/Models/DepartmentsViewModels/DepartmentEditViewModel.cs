using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskListApp.Web.Areas.Admin.Models.DepartmentsViewModels;

namespace TaskListApp.Web.Areas.Admin.Models.DepartmentsViewModels {
    public class DepartmentEditViewModel 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? HeadId { get; set; }
        public IEnumerable<SelectListItem> EmployeesList 
        {
            get 
            {
                if (Employees != null) 
                {
                    return Employees.Select(e => new SelectListItem { Text = $"{e.Name} {e.Surname}", Value = e.Id.ToString() });
                }

                return new List<SelectListItem>();
            }
        }

        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}