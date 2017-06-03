using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Domain.Filters;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.Contracts.BLLContracts.Services
{
    public interface IUserService : IBaseService<User>
    {
        IEnumerable<User> GetUsersByFilter(UserFilter filter);
        IEnumerable<User> GetUsersByFilter(EmployeeFilter filter);
        Task SetRoleToUser(Guid userId, string role);
        void BlockUser(Guid userId);
        void UnblockUser(Guid userId);
        bool DeleteUser(Guid userId);

        IEnumerable<User> GetUsersByDepartment(Guid departmentId);
        
    }
}
