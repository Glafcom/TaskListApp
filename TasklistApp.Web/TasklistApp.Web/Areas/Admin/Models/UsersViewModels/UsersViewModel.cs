using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Domain.Filters;

namespace TasklistApp.Web.Areas.Admin.Models.UsersViewModels
{
    public class UsersViewModel
    {
        public UserFilter Filter { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}