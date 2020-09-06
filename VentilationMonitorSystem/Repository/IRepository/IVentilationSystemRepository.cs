using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentilationMonitorSystem.Models;

namespace VentilationMonitorSystem.Repository.IRepository
{
    public interface IVentilationSystemRepository
    {
        ICollection<VentilationMonitorModel> GetVentilationSystems();
        VentilationMonitorModel GetVentilationSystem(System.Guid recordId);
        bool VentilationSystemExists(System.Guid recordId);
        bool CreateVentilationSystem(VentilationMonitorModel ventilationMonitor);
        bool UpdateVentilationSystem(VentilationMonitorModel ventilationMonitor);
        bool DeleteVentilationSystem(System.Guid recordId);
        ICollection<DepartmentModel> GetDepartments();
        bool Save();
    }
}
