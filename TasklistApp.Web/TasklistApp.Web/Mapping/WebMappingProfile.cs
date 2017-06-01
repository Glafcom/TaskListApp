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
using TaskListApp.Web.Areas.User.Models.ToDoTasksViewModels;

namespace TasklistApp.Web.Mapping {
    public class WebMappingProfile : Profile {

        public WebMappingProfile() {

            #region [ Admin area ]

            #region [ Department models ]

            CreateMap<DepartmentViewModel, Department>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<DepartmentBlankViewModel, Department>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<Department, DepartmentViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<Department, DepartmentBlankViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<IndexDepartmentViewModel, Department>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<Department, IndexDepartmentViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<UserDepartmentViewModel, Department>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<Department, UserDepartmentViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();

            #endregion // [ Department models ]

            #region [ Users models ]

            CreateMap<UserViewModel, User>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<User, UserViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<EmployeeViewModel, User>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<User, EmployeeViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<HeadViewModel, User>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<User, HeadViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<ToDoTaskUserViewModel, User>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<User, ToDoTaskUserViewModel>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();

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