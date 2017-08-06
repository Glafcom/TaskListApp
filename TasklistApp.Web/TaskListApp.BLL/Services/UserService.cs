using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Common.Helpers;
using TaskListApp.Contracts.BLLContracts.Services;
using TaskListApp.Contracts.DALContracts;
using TaskListApp.Contracts.DALContracts.Identity;
using TaskListApp.Contracts.DtoModels;
using TaskListApp.Domain.Enums;
using TaskListApp.Domain.Filters;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.BLL.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        protected readonly IApplicationUserManager _userManager;
        protected readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> itemRepository, IApplicationUserManager userManager, IGenericRepository<User> userRepository)
            : base(itemRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public UserDto GetUser(Guid userId) {
            var user = GetItem(userId);
            return new UserDto {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Surname = user.Surname,
                IsBlocked = user.IsBlocked,
                Role = (user.Roles.FirstOrDefault() != null && user.Roles.ToList().FirstOrDefault().Role != null)
                        ? user.Roles.ToList().FirstOrDefault().Role.Name
                        : string.Empty,
                DepartmentId = user.DepartmentId,
                Email = user.Email
            };
        }

        public IEnumerable<UserDto> GetUsers() {
            var test = _userRepository.Get();
            var test2 = test.FirstOrDefault();

            var users = _userRepository.Get()
                .Select(u => new UserDto {
                    Id = u.Id,
                    UserName = u.UserName,
                    Name = u.Name,
                    Surname = u.Surname,
                    IsBlocked = u.IsBlocked,
                    Role = (u.Roles.FirstOrDefault() != null && u.Roles.FirstOrDefault().Role != null)
                        ? u.Roles.ToList().FirstOrDefault().Role.Name
                        : string.Empty,
                    DepartmentId = u.DepartmentId,
                    Email = u.Email
                });
            return users;
            
        }

        public IEnumerable<UserDto> GetUsersByFilter(UserFilter filter)
        {
            var users = GetUsers();

            if (!string.IsNullOrEmpty(filter.UserName))
                users = users.Where(u => u.UserName.Contains(filter.UserName));

            if (!string.IsNullOrEmpty(filter.Name))
                users = users.Where(u => u.Name.Contains(filter.Name));

            if (!string.IsNullOrEmpty(filter.Surname))
                users = users.Where(u => u.Surname.Contains(filter.Surname));

            if (filter.Department.HasValue)
                users = users.Where(u => u.DepartmentId != null && u.DepartmentId == filter.Department);

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

        public IEnumerable<UserDto> GetEmployees() {
            return GetUsers().Where(u => u.Role == UserType.Employee.ToString());
        }

        public IEnumerable<UserDto> GetEmployeesByFilter(UserFilter filter) {
            return GetUsersByFilter(filter).Where(u => u.Role == UserType.Employee.ToString());
        }

        public IEnumerable<UserDto> GetEmployeesByFilter(EmployeeFilter filter) {
            var employees = GetEmployees();

            if (!string.IsNullOrEmpty(filter.Name))
                employees = employees.Where(u => u.Name.Contains(filter.Name));

            if (!string.IsNullOrEmpty(filter.Surname))
                employees = employees.Where(u => u.Surname.Contains(filter.Surname));

            if (filter.Department.HasValue)
                employees = employees.Where(u => u.DepartmentId != null && u.DepartmentId == filter.Department);
            
            return employees;
        }

        public IEnumerable<UserDto> GetEmployeesByDepartment(Guid departmentId) {
            return GetEmployees().Where(e => e.DepartmentId.HasValue && e.DepartmentId == departmentId);
        }

        public async Task SetRoleToUser(Guid userId, UserType userType) {
            var user = GetItem(userId);
            ChangeItem(userId, user);
            await SetRoleToUser(userId, userType.ToString());
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

            if (user.IsBlocked != null && (bool)user.IsBlocked) {
                DeleteItem(userId);
                return true;
            }

            return false;            
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
