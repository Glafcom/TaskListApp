using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasklistApp.Web.Hubs;
using TaskListApp.Contracts.BLLContracts.Domains;
using TaskListApp.Domain.Enums;
using TaskListApp.Domain.Models;
using TaskListApp.Web.Areas.User.Models.EmployeesViewModels;
using TaskListApp.Web.Areas.User.Models.ToDoTasksViewModels;

namespace TaskListApp.Web.Areas.User.Controllers
{
    [Authorize(Roles = "Boss,Head,Employee")]
    public class TasksController : Controller
    {
        protected readonly IUserDomain _userDomain;

        public TasksController(IUserDomain userDomain)
        {
            _userDomain = userDomain;
        }

        // GET: User/Tasks
        public ActionResult Index()
        {
            var model = new ToDoTaskIndexViewModel
            {
                ActualOwnTasks = _userDomain.GetActualOwnToDoTasks().Select(aot => Mapper.Map<ToDoTaskViewModel>(aot)),
                ActualAssignedTasks = _userDomain.GetActualAssignedToDoTasks().Select(aot => Mapper.Map<ToDoTaskViewModel>(aot)),
                AllEmployees = _userDomain.GetAllEmployees().Select(e => new TaskListEmployeeViewModel {
                    
                })

            };
            return View(model);
        }

        public ActionResult Task(Guid id)
        {
            var toDoTask = _userDomain.GetToDoTask(id);
            var model = Mapper.Map<ToDoTaskDetailViewModel>(toDoTask);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ToDoTaskBlankViewModel();
            model.DepartmentsList = _userDomain.GetDepartments()
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name }).ToList();
            model.EmployeesList = new List<SelectListItem>();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ToDoTaskBlankViewModel model)
        {
            var toDoTask = Mapper.Map<ToDoTask>(model);
            _userDomain.CreateToDoTask(toDoTask);
            TaskListHub.CreateToDoTask(toDoTask);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var toDoTask = _userDomain.GetToDoTask(id);
            var model = Mapper.Map<ToDoTaskBlankViewModel>(toDoTask);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ToDoTaskBlankViewModel model)
        {
            var toDoTask = Mapper.Map<ToDoTask>(model);
            _userDomain.EditToDoTask(toDoTask);
            TaskListHub.EditToDoTask(toDoTask);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var toDoTask = _userDomain.GetToDoTask(id);
            _userDomain.DeleteToDoTask(id);
            TaskListHub.DeleteToDoTask(id, toDoTask.Assignee.UserName);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult RejectTask(Guid id)
        {
            return View(new ToDoTaskChangeStatusViewModel() { Id = id, Status = ToDoTaskStatus.Rejected });
        }

        [HttpGet]
        public ActionResult CloseTask(Guid id)
        {
            return View(new ToDoTaskChangeStatusViewModel() { Id = id, Status = ToDoTaskStatus.Done });
        }
                
        [HttpPost]
        public ActionResult ChangeTaskStatus(ToDoTaskChangeStatusViewModel model)
        {
            var toDoTask = _userDomain.GetToDoTask(model.Id);

            switch (model.Status)
            {
                case ToDoTaskStatus.Done:
                    _userDomain.CompliteToDoTask(model.Id, model.Information);
                    break;
                case ToDoTaskStatus.Rejected:
                    _userDomain.RejectToDoTask(model.Id, model.Information);
                    break;
            }
            TaskListHub.ChangeToDoTaskStatus(model.Id, model.Status, model.Information, toDoTask.Assignee.UserName);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public void StopTask(Guid id)
        {
            _userDomain.StopToDoTaskExecuting(id);
        }

        [HttpPost]
        public void StartTask(Guid id)
        {
            _userDomain.StartToDoTaskExecuting(id);
        }

        [HttpGet]
        public JsonResult GetUsersList(Guid departmentId)
        {
            List<SelectListItem> result;
            result = _userDomain.GetEmployeesByDepartment(departmentId)
                .Select(e => new SelectListItem { Text = $"{e.Name} {e.Surname}", Value = e.Id.ToString()}).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetActiveUsersList(string[] usersNames) {
            var employees = _userDomain.GetAllEmployees().Where(e => usersNames.Contains(e.UserName)).Select(e => new TaskListEmployeeViewModel {
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                Email = e.Email,
                IsOnline = true,
                Department = Mapper.Map<DepartmentViewModel>(e.Department),
                Status = 
            });

        }
    }
}