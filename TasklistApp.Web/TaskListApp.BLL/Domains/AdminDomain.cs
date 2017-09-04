using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Contracts.BLLContracts.Domains;
using TaskListApp.Contracts.BLLContracts.Services;
using TaskListApp.Contracts.DtoModels;
using TaskListApp.Domain.Enums;
using TaskListApp.Domain.Filters;
using TaskListApp.Domain.Models;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.BLL.Domains
{
    public class AdminDomain : User, IAdminDomain
    {
        protected readonly IDepartmentService _departmentService;
        protected readonly IUserService _userService;

        public AdminDomain(IUserService userService, IDepartmentService departmentService)
        {
            _userService = userService;
            _departmentService = departmentService;
        }

        #region Users methods

        public IEnumerable<UserDto> GetUsersByFilter(UserFilter filter)
        {
            return _userService.GetUsersByFilter(filter);
        }

        public IEnumerable<UserDto> GetEmployeesByFilter(UserFilter filter) {
            return _userService.GetEmployeesByFilter(filter);
        }

        public IEnumerable<UserDto> GetEmployeesByFilter(EmployeeFilter filter) {
            return _userService.GetEmployeesByFilter(filter);
        }

        public UserDto GetUser(Guid userId) 
        {
            return _userService.GetUser(userId);
        }

        public async Task EditUser(UserDto user) 
        {
            _userService.UpdateUser(Mapper.Map<User>(user));
            await _userService.SetRoleToUser(user.Id, user.Role);
        }

        public void BlockUser(Guid userId)
        {
            _userService.BlockUser(userId);
        }

        public void UnblockUser(Guid userId)
        {
            _userService.UnblockUser(userId);
        }

        public void ChangeUserRole(Guid userId, UserType role)
        {
            _userService.SetRoleToUser(userId, role);
        }

        public void DeleteUser(Guid userId)
        {
            _userService.DeleteUser(userId);
        }

        #endregion


        #region Department methods

        public IEnumerable<Department> GetDepartments() 
        {
            return _departmentService.GetItems();
        }

        public IEnumerable<Department> GetDepartmentsByFilter(DepartmentFilter filter)
        {
            return _departmentService.GetDeparmentsByFilter(filter);
        }

        public Department GetDepartment(Guid departmentId)
        {
            return _departmentService.GetItem(departmentId);
        }

        public void CreateDepartment(Department department)
        {
            _departmentService.AddItem(department);
        }

        public void ChangeDepartment(Department department)
        {
            _departmentService.ChangeItem(department.Id, department);
        }

        public void DeleteDepartment(Guid departmentId)
        {
            _departmentService.DeleteItem(departmentId);
        }

        public void DeleteEmployeeFromDepartment(Guid departmentId, Guid employeeId) 
        {
            var employee = _userService.GetItem(employeeId);
            employee.DepartmentId = null;
            _userService.ChangeItem(employeeId, employee);
        }

        #endregion

    }
}
