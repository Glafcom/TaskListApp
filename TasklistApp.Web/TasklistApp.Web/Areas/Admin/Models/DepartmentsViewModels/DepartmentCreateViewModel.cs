using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskListApp.Web.Areas.Admin.Models.DepartmentsViewModels
{
    public class DepartmentCreateViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}