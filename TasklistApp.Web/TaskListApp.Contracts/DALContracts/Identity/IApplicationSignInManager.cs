﻿using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.Contracts.DALContracts.Identity
{
    public interface IApplicationSignInManager
    {
        Task SignInAsync(User user, bool isPersistent, bool rememberBrowser);
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);
    }
}
