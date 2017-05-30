using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListApp.Contracts.MapperProfiles {
    public class WebMapperProfile : Profile
    {
        public WebMapperProfile() 
        {
            #region [ Admin Area Methods ]

            #region [ Departments models ]

            CreateMap<DepartmentViewModel, Department>();

            #region //[ Departments models ]

            #endregion //[ Admin Area Models ]
        }
    }
}
