using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Contracts.DtoModels;
using TaskListApp.Domain.Enums;
using TaskListApp.Domain.Filters;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.Contracts.BLLContracts.Services
{
    public interface IUserService : IBaseService<User>
    {
        UserDto GetUser(Guid userId);
        IEnumerable<UserDto> GetUsers();
        IEnumerable<UserDto> GetUsersByFilter(UserFilter filter);
        IEnumerable<Role> GetUserRoles(Guid userId);
        Task SetRoleToUser(Guid userId, string role);
        Task SetRoleToUser(Guid userId, UserType userType);
        void BlockUser(Guid userId);
        void UnblockUser(Guid userId);
        bool DeleteUser(Guid userId);
        void UpdateUser(User user);

        IEnumerable<UserDto> GetEmployees();
        IEnumerable<UserDto> GetEmployeesByFilter(UserFilter filter);
        IEnumerable<UserDto> GetEmployeesByFilter(EmployeeFilter filter);

        IEnumerable<UserDto> GetEmployeesByDepartment(Guid departmentId);
        
    }
}
