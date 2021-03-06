﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Domain.Enums;

namespace TaskListApp.Web.Areas.Admin.Models.UsersViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        public UserType Role { get; set; }
        public Guid? DepartmentId { get; set; }
        public UserDepartmentViewModel Department { get; set; }
         
    }

    public class UserDepartmentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}