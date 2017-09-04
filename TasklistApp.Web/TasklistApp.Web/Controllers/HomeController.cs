using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TaskListApp.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Roles.IsUserInRole("Admin"))
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            if (Roles.IsUserInRole("Employee"))
                return RedirectToAction("Index", "Tasks", new { area = "User" });

            return RedirectToAction("Login", "Account", new { area = "Account" });
        }
    }
}