using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Contracts.DtoModels;
using TaskListApp.Domain.Enums;
using TaskListApp.Domain.Filters;
using TaskListApp.Domain.Models;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.Contracts.BLLContracts.Domains
{
    public interface IAdminDomain
    {
        #region Users methods

        IEnumerable<UserDto> GetUsersByFilter(UserFilter filter);
        IEnumerable<UserDto> GetEmployeesByFilter(UserFilter filter); 
        IEnumerable<UserDto> GetEmployeesByFilter(EmployeeFilter filter);
        UserDto GetUser(Guid userId);
        void EditUser(User user);
        void BlockUser(Guid userId);
        void UnblockUser(Guid userId);
        void ChangeUserRole(Guid userId, UserType role);
        void DeleteUser(Guid userId);


        #endregion

        #region Departments methods

        IEnumerable<Department> GetDepartments();
        IEnumerable<Department> GetDepartmentsByFilter(DepartmentFilter filter);
        Department GetDepartment(Guid departmentId);
        void CreateDepartment(Department department);
        void ChangeDepartment(Department department);
        void DeleteDepartment(Guid departmentId);
        void DeleteEmployeeFromDepartment(Guid departmentId, Guid employeeId);

        #endregion
    }
}
