using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TaskListApp.BLL.Domains;
using TaskListApp.BLL.Identity;
using TaskListApp.BLL.Services;
using TaskListApp.Contracts.BLLContracts.Domains;
using TaskListApp.Contracts.BLLContracts.Services;
using TaskListApp.Contracts.DALContracts;
using TaskListApp.Contracts.DALContracts.Identity;
using TaskListApp.DAL.AppDbContext;
using TaskListApp.DAL.Repositories;
using TaskListApp.Domain.Models;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.Infrastructure.ContainerExtensions {
    public class TaskListAppContainerExtension : UnityContainerExtension {

        protected override void Initialize() {

            #region [ BLL Layer ]

            #region [ Services ]

            Container.RegisterType<IAccountService, AccountService>(new PerRequestLifetimeManager());
            Container.RegisterType<IDepartmentService, DepartmentService>(new PerRequestLifetimeManager());
            Container.RegisterType<IToDoTaskService, ToDoTaskService>(new PerRequestLifetimeManager());
            Container.RegisterType<IUserService, UserService>(new PerRequestLifetimeManager());
            Container.RegisterType<IUserStore<User, Guid>, ApplicationUserStore>(new PerRequestLifetimeManager());
            Container.RegisterType<IAuthenticationManager>(new PerRequestLifetimeManager(), new InjectionFactory( o => System.Web.HttpContext.Current.GetOwinContext().Authentication ));

            #endregion //[ Services ]

            #region [ Domains ]

            Container.RegisterType<IAdminDomain, AdminDomain>(new PerRequestLifetimeManager());
            Container.RegisterType<IUserDomain, UserDomain>(new PerRequestLifetimeManager());

            #endregion //[ Domains ]

            #endregion //[ BLL Layer ] 

            #region [ DAL Layer ]


            Container.RegisterType<TaskListAppDbContext>(new PerRequestLifetimeManager(), new InjectionConstructor("TaskListAppDbConnection"));
            Container.RegisterType<DbContext, TaskListAppDbContext>(new PerRequestLifetimeManager());
            Container.RegisterType<IApplicationSignInManager, ApplicationSignInManager>(new PerRequestLifetimeManager());
            Container.RegisterType<IApplicationUserManager, ApplicationUserManager>(new PerRequestLifetimeManager());

            #region [ Repositories ]

            Container.RegisterType<IGenericRepository<User>, GenericRepository<User>>(new PerRequestLifetimeManager());
            Container.RegisterType<IGenericRepository<Department>, GenericRepository<Department>>(new PerRequestLifetimeManager());
            Container.RegisterType<IGenericRepository<ToDoTask>, GenericRepository<ToDoTask>>(new PerRequestLifetimeManager());
            Container.RegisterType<IGenericRepository<Role>, GenericRepository<Role>>(new PerRequestLifetimeManager());

            #endregion // [ Repositories ]

            #endregion // [ DAL Layer ]
        }
    }
}
