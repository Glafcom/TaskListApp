using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskListApp.Contracts.BLLContracts.Domains;
using TaskListApp.Domain.Filters;
using TaskListApp.Web.Areas.User.Models.EmployeesViewModels;

namespace TasklistApp.Web.Areas.User.Controllers
{
    public class EmployeesController : Controller
    {
        protected readonly IUserDomain _userDomain;

        public EmployeesController(IUserDomain userDomain) 
        {
            _userDomain = userDomain;
        }

        // GET: User/Employees
        public ActionResult Index(EmployeeFilter filter)
        {
            var model = new EmployeesViewModel {
                Filter = filter,
                Employees = _userDomain.GetEmployeesByFilter(filter)
                    .Select(e => Mapper.Map<EmployeeViewModel>(e))
            };
            return View(model);
        }

        public ActionResult Employee(Guid id) 
        {
            var employee = _userDomain.GetEmployee(id);
            var model = Mapper.Map<EmployeeViewModel>(employee);
            return View(model);
        }

        public ActionResult EmployeeTasks(Guid id) 
        {
            
        }
    }
}