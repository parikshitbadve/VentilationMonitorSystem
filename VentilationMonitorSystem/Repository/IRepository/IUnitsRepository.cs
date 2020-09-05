using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentilationMonitorSystem.Models;

namespace VentilationMonitorSystem.Repository.IRepository
{
   public interface IUnitsRepository
    {
        ICollection<UnitModel> GetUnits();
        UnitModel GetUnit(System.Guid recordId);
        bool unitExists(System.Guid recordId);
        bool CreateUnit(UnitModel ventilationMonitor);
        bool UpdateUnit(UnitModel ventilationMonitor);
        bool DeleteUnit(UnitModel ventilationMonitor);
        bool Save();
    }
}
