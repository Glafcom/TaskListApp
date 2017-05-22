using Areas.User.Models.ToDoTasksViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskListApp.Contracts.BLLContracts.Domains;
using TaskListApp.Domain.Enums;
using TaskListApp.Domain.Models;
using TaskListApp.Web.Areas.User.Models.ToDoTasksViewModels;

namespace TaskListApp.Web.Areas.User.Controllers
{
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
                ActualAssignedTasks = _userDomain.GetActualAssignedToDoTasks().Select(aot => Mapper.Map<ToDoTaskViewModel>(aot))
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
            return View(new ToDoTaskBlankViewModel());
        }

        [HttpPost]
        public ActionResult Create(ToDoTaskBlankViewModel model)
        {
            var toDoTask = Mapper.Map<ToDoTask>(model);
            _userDomain.CreateToDoTask(toDoTask);
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
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            _userDomain.DeleteToDoTask(id);
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
            switch (model.Status)
            {
                case ToDoTaskStatus.Done:
                    _userDomain.CompliteToDoTask(model.Id, model.Information);
                    break;
                case ToDoTaskStatus.Rejected:
                    _userDomain.RejectToDoTask(model.Id, model.Information);
                    break;
            }

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
    }
}