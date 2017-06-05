using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Common.Extensions;
using TaskListApp.Contracts.DtoModels;
using TaskListApp.Domain.Models;
using TaskListApp.Domain.Models.Identity;
using TaskListApp.Web.Areas.Account.Models.AccountViewModels;
using TaskListApp.Web.Areas.Admin.Models.DepartmentsViewModels;
using TaskListApp.Web.Areas.Admin.Models.UsersViewModels;
using TaskListApp.Web.Areas.User.Models.EmployeesViewModels;
using TaskListApp.Web.Areas.User.Models.ToDoTasksViewModels;

namespace TasklistApp.Web.Mapping {
    public class WebMappingProfile : Profile {

        public WebMappingProfile() {

            #region [ Admin area ]

            #region [ Department models ]

            CreateMap<TaskListApp.Web.Areas.Admin.Models.DepartmentsViewModels.DepartmentViewModel, Department>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<DepartmentCreateViewModel, Department>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<DepartmentEditViewModel, Department>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<Department, TaskListApp.Web.Areas.Admin.Models.DepartmentsViewModels.DepartmentViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<Department, DepartmentCreateViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<Department, DepartmentEditViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<IndexDepartmentViewModel, Department>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<Department, IndexDepartmentViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<UserDepartmentViewModel, Department>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<Department, UserDepartmentViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();

            #endregion // [ Department models ]

            #region [ Users models ]

            CreateMap<UserViewModel, User>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<User, UserViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<TaskListApp.Web.Areas.Admin.Models.DepartmentsViewModels.EmployeeViewModel, User>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<User, TaskListApp.Web.Areas.Admin.Models.DepartmentsViewModels.EmployeeViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<HeadViewModel, User>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<User, HeadViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<ToDoTaskUserViewModel, User>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<User, ToDoTaskUserViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<UserDetailViewModel, User>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<User, UserDetailViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();

            #endregion //[ Users models ]

            #endregion //[ Admin area ]

            #region [ User area ]

            #region [ ToDoTasks models ]

            CreateMap<ToDoTaskViewModel, ToDoTask>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<ToDoTaskIndexViewModel, ToDoTask>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<ToDoTaskDetailViewModel, ToDoTask>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<ToDoTaskBlankViewModel, ToDoTask>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<ToDoTask, ToDoTaskViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<ToDoTask, ToDoTaskIndexViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<ToDoTask, ToDoTaskDetailViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<ToDoTask, ToDoTaskBlankViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();

            #endregion //[ ToDoTasks models ]

            #region [ Employees models ]

            CreateMap<TaskListApp.Web.Areas.User.Models.EmployeesViewModels.EmployeeViewModel, User>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<User, TaskListApp.Web.Areas.User.Models.EmployeesViewModels.EmployeeViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<TaskListEmployeeViewModel, User>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<User, TaskListEmployeeViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<TaskListApp.Web.Areas.User.Models.EmployeesViewModels.DepartmentViewModel, Department>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<Department, TaskListApp.Web.Areas.User.Models.EmployeesViewModels.DepartmentViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();

            #endregion // [ Employees models ]

            #endregion //[ User area ]

            #region [ Account models ]

            CreateMap<RegisterViewModel, UserDto>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<LoginViewModel, UserDto>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<UserDto, User>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<User, UserDto>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();

            #endregion //[ Account models ]


        }

    }
}