﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Contracts.BLLContracts.Domains;
using TaskListApp.Contracts.BLLContracts.Services;
using TaskListApp.Contracts.DtoModels;
using TaskListApp.Domain.Filters;
using TaskListApp.Domain.Models;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.BLL.Domains
{
    public class UserDomain : User, IUserDomain
    {
        protected readonly IToDoTaskService _toDoTaskService;
        protected readonly IUserService _userService;
        protected readonly IDepartmentService _departmentService;

        public UserDomain(IToDoTaskService toDoTaskService, IUserService userService, IDepartmentService departmentService)
        {
            _toDoTaskService = toDoTaskService;
            _userService = userService;
            _departmentService = departmentService;
        }

        #region [ ToDoTasks Methods ]

        public IEnumerable<ToDoTask> GetOwnToDoTasks()
        {
            return _toDoTaskService.GetOwnToDoTasks(this.Id);
        }

        public IEnumerable<ToDoTask> GetActualOwnToDoTasks()
        {
            return _toDoTaskService.GetActualOwnToDoTasks(this.Id);
        }

        public ToDoTask GetOwnToDoTask(Guid toDoTaskId)
        {
            return _toDoTaskService.GetOwnToDoTask(this.Id, toDoTaskId);
        }

        public IEnumerable<ToDoTask> GetActualAssignedToDoTasks()
        {
            return _toDoTaskService.GetActualAssignedToDoTasks(this.Id);
        }

        public IEnumerable<ToDoTask> GetAssignedToDoTasks()
        {
            return _toDoTaskService.GetAssignedToDoTasks(this.Id);
        }

        public ToDoTask GetAssignedToDoTask(Guid toDoTaskId)
        {
            return _toDoTaskService.GetAssignedToDoTask(this.Id, toDoTaskId);
        }

        public ToDoTask GetToDoTask(Guid toDoTaskId)
        {
            return _toDoTaskService.GetItem(toDoTaskId);
        }

        public void CreateToDoTask(ToDoTask toDoTask)
        {
            _toDoTaskService.AddItem(toDoTask);
        }

        public void EditToDoTask(ToDoTask toDoTask)
        {
            _toDoTaskService.ChangeItem(toDoTask.Id, toDoTask);
        }

        public void DeleteToDoTask(Guid toDoTaskId)
        {
            _toDoTaskService.DeleteItem(toDoTaskId);
        }

        public void RejectToDoTask(Guid toDoTaskId, string info)
        {
            _toDoTaskService.RejectToDoTask(toDoTaskId, info);
        }
        public void CompliteToDoTask(Guid toDoTaskId, string info)
        {
            _toDoTaskService.CompliteToDoTask(toDoTaskId, info);
        }

        public void StopToDoTaskExecuting(Guid toDoTaskId)
        {
            _toDoTaskService.StopToDoTaskExecuting(toDoTaskId);
        }

        public void StartToDoTaskExecuting(Guid toDoTaskId)
        {
            _toDoTaskService.StartToDoTaskExecuting(toDoTaskId);
        }

        public IEnumerable<ToDoTask> GetActiveTasksOfUser(Guid userId) 
        {
            return _toDoTaskService.GetActualAssignedToDoTasks(userId);
        }

        #endregion // [ ToDoTasks Methods ]

        #region [ Eployees Methods ]

        public IEnumerable<UserDto> GetAllEmployees() {
            return _userService.GetEmployees();
        }

        public IEnumerable<UserDto> GetEmployeesByDepartment(Guid departmentId)
        {
            return _userService.GetEmployeesByDepartment(departmentId);
        }

        public IEnumerable<UserDto> GetEmployeesByFilter(EmployeeFilter filter) 
        {
            return _userService.GetEmployeesByFilter(filter);
        }

        public UserDto GetEmployee(Guid employeeId) 
        {
            return _userService.GetUser(employeeId);
        }

        #endregion // [ Employees Methods ]

        #region [ Departments Methods ]

        public IEnumerable<Department> GetDepartments() {
            return _departmentService.GetItems();
        }

        #endregion // [ Departments Methods ]
    }
}
