using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Domain.Enums;
using TaskListApp.Domain.Filters;
using TaskListApp.Domain.Models;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.Contracts.BLLContracts.Domains
{
    public interface IAdminDomain
    {
        #region Users methods

        IEnumerable<User> GetUsersByFilter(UserFilter filter);
        void BlockUser(Guid userId);
        void UnblockUser(Guid userId);
        void ChangeUserRole(Guid userId, UserType role);
        void DeleteUser(Guid userId);


        #endregion

        #region Departments methods

        IEnumerable<Department> GetDepartmentsByFilter(DepartmentFilter filter);
        Department GetDepartment(Guid departmentId);
        void CreateDepartment(Department department);
        void ChangeDepartment(Department department);
        void DeleteDepartment(Guid departmentId); 


        #endregion
    }
}
