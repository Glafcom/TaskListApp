using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Contracts.BLLContracts.Services;
using TaskListApp.Contracts.DALContracts;
using TaskListApp.Contracts.DALContracts.Identity;
using TaskListApp.Domain.Enums;
using TaskListApp.Domain.Filters;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.BLL.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        protected readonly IApplicationUserManager _userManager;

        public UserService(IGenericRepository<User> itemRepository, IApplicationUserManager userManager)
            : base(itemRepository)
        {
            _userManager = userManager;
        }

        public IEnumerable<User> GetUsersByFilter(UserFilter filter)
        {
            var users = GetItems();

            if (!string.IsNullOrEmpty(filter.UserName))
                users = users.Where(u => u.UserName.Contains(filter.UserName));

            if (!string.IsNullOrEmpty(filter.Name))
                users = users.Where(u => u.Name.Contains(filter.Name));

            if (!string.IsNullOrEmpty(filter.Surname))
                users = users.Where(u => u.Surname.Contains(filter.Surname));

            if (filter.Department.HasValue)
                users = users.Where(u => u.Department != null && (Guid)u.DepartmentId == (Guid)filter.Department);

            if (filter.Role.HasValue)
                users = users.Where(u => _userManager.IsInRoleAsync(u.Id,filter.Role.ToString()).Result);

            if (filter.Status.HasValue)
            {
                if ((UserStatus)filter.Status == UserStatus.Active)
                    users = users.Where(u => !u.IsBlocked.HasValue || !(bool)u.IsBlocked);
                if ((UserStatus)filter.Status == UserStatus.Blocked)
                    users = users.Where(u => u.IsBlocked.HasValue && (bool)u.IsBlocked);
            }

            return users;
        }

        public async Task SetRoleToUser(Guid userId, string role)
        {
            var roles = await _userManager.GetRolesAsync(userId);
            await _userManager.RemoveFromRolesAsync(userId, roles.ToArray());
            await _userManager.AddToRoleAsync(userId, role);
        }

        public void BlockUser(Guid userId)
        {
            ChangeUserStatus(userId, true);
        }

        public void UnblockUser(Guid userId)
        {
            ChangeUserStatus(userId, false);
        }

        public bool DeleteUser(Guid userId)
        {
            var user = GetItem(userId);

            if (user.IsBlocked != null && (bool)user.IsBlocked)
                return false;

            DeleteItem(userId);

            return true;
        }

        public IEnumerable<User> GetUsersByDepartment(Guid departmentId)
        {
            return GetItems().Where(u => u.DepartmentId == departmentId);
        }

        private void ChangeUserStatus(Guid userId, bool isBlocked)
        {
            var user = _itemRepository.GetByID(userId);
            user.IsBlocked = isBlocked;
            ChangeItem(userId, user);
        }

    }
}
