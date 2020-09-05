using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentilationMonitorSystem.Models;

namespace VentilationMonitorSystem.VentilationMapper
{
    public class VentilationMapping :Profile
    {
        public VentilationMapping()
        {
            CreateMap<VentilationMonitorModel, VentilationMonitorDto>().ReverseMap();
            CreateMap<DepartmentModel, DepartmentDto>().ReverseMap();
            CreateMap<UnitModel, UnitDto>().ReverseMap();
        }
    }
}
