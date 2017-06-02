using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TasklistApp.Web.Areas.User.Controllers
{
    [Authorize(Roles = "Boss,Head,Employee")]
    public class HomeController : Controller
    {
        // GET: User/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}