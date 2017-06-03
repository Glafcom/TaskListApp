using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskListApp.Web.Areas.Admin.Models.DepartmentsViewModels;

namespace TaskListApp.Web.Areas.Admin.Models.UsersViewModels {
    public class UserIndexViewModel : UsersViewModel 
    {
        public IEnumerable<SelectListItem> DepartmentsList { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}