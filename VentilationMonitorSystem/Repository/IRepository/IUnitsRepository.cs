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
        bool unitExists(string unitName);
        UnitModel CreateUnit(string unitName);
        bool UpdateUnit(UnitModel unit);
        bool DeleteUnit(UnitModel unit);
        bool Save();
    }
}
