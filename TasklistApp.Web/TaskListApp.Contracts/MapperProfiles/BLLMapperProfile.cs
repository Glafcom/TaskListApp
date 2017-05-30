using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Common.Extensions;
using TaskListApp.Contracts.DtoModels;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.Contracts.MapperProfiles {
    public class BLLMapperProfile : Profile {

        
        protected override void Configure() {


            #region Account models

            CreateMap<User, UserDto>().IgnoreAllNonExisting();
            CreateMap<UserDto, User>().IgnoreAllNonExisting();

            #endregion

        }
    }
}
