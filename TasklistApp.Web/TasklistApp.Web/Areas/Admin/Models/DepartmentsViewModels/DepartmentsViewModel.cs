using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Domain.Filters;

namespace TaskListApp.Web.Areas.Admin.Models.DepartmentsViewModels
{
    public class DepartmentsViewModel
    {
        public DepartmentFilter Filter { get; set; }
        public IEnumerable<IndexDepartmentViewModel> Departments { get; set; }

    }

    public class IndexDepartmentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public HeadViewModel Head {get;set;} 
        public int PersonalCount { get; set; }
    }

    public class HeadViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}