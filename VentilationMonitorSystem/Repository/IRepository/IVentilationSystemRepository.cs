using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentilationMonitorSystem.Models;

namespace VentilationMonitorSystem.Repository.IRepository
{
    public interface IVentilationSystemRepository
    {
        ICollection<VentilationMonitorDto> GetVentilationSystems();
        VentilationMonitorDto GetVentilationSystem(System.Guid recordId);
        bool VentilationSystemExists(System.Guid recordId);
        bool CreateVentilationSystem(VentilationMonitorDto ventilationMonitor);
        bool UpdateVentilationSystem(VentilationMonitorDto ventilationMonitor);
        bool DeleteVentilationSystem(VentilationMonitorDto ventilationMonitor);
        bool Save();
    }
}
