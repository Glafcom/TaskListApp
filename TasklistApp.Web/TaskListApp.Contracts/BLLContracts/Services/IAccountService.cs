using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Common.Models;
using TaskListApp.Contracts.DtoModels;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.Contracts.BLLContracts.Services {
    public interface IAccountService {
        Task<OperationDetails> Create(UserDto userDto);
        Task<ClaimsIdentity> Authenticate(UserDto userDto);
        Task<OperationDetails> ConfirmEmail(Guid userId, string code);
        Task<OperationDetails> ResetPassword(string email, string code, string password);
        Task<OperationDetails> SendCodeToRetrievePassword(string email);
        Task SignIn(User user, bool isPersistent, bool rememberMe);
        Task<SignInStatus> SignIn(string userName, string password, bool rememberMe, bool shouldLockout);
    }
}
