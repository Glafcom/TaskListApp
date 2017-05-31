using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TasklistApp.Web.Mapping;

namespace TasklistApp.Web.App_Start {
    public class AutomapperConfig {
        public static void CreateMap() {
            Mapper.Initialize(cfg => cfg.AddProfile<WebMappingProfile>());
            Mapper.AssertConfigurationIsValid();
        }
    }
}