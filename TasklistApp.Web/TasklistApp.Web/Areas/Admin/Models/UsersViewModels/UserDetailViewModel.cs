using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskListApp.Web.Areas.Admin.Models.UsersViewModels {
    public class UserDetailViewModel : UserViewModel 
    {
        public IEnumerable<SelectListItem> DepartmentsList { get; set; }
        public string ReturnUrl { get; set; }
    }
}