using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskListApp.Contracts.BLLContracts.Domains;
using TaskListApp.Domain.Enums;
using TaskListApp.Domain.Filters;
using TaskListApp.Web.Areas.Admin.Models.UsersViewModels;

namespace TasklistApp.Web.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        protected IAdminDomain _adminDomain;

        public UsersController(IAdminDomain adminDomain)
        {
            _adminDomain = adminDomain;
        }

        // GET: Admin/Users
        public ActionResult Index(UserFilter filter)
        {
            var users = _adminDomain.GetUsersByFilter(filter);
            var model = new UsersViewModel
            {
                Filter = filter,
                Users = users.Select(u => Mapper.Map<UserViewModel>(u))
            };
            return View(model);
        }

        [HttpPost]
        public void BlockUser(Guid userId)
        {
            _adminDomain.BlockUser(userId);
        }

        [HttpPost]
        public void UnblockUser(Guid userId)
        {
            _adminDomain.UnblockUser(userId);
        }

        [HttpPost]
        public void DeleteUser(Guid userId)
        {
            _adminDomain.DeleteUser(userId);
        }

        public void ChangeUserRole(Guid userId, RoleType role)
        {
            _adminDomain.ChangeUserRole(userId, role);
        }
    }
}