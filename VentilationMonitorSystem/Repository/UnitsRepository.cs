using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentilationMonitorSystem.Data;
using VentilationMonitorSystem.Models;
using VentilationMonitorSystem.Repository.IRepository;

namespace VentilationMonitorSystem.Repository
{
    public class UnitsRepository : IUnitsRepository
    {
        private readonly ApplicationDbContext _db;
        public UnitsRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateUnit(UnitModel ventilationMonitor)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUnit(UnitModel ventilationMonitor)
        {
            throw new NotImplementedException();
        }

        public UnitModel GetUnit(Guid recordId)
        {
            throw new NotImplementedException();
        }

        public ICollection<UnitModel> GetUnits()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool unitExists(Guid recordId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUnit(UnitModel ventilationMonitor)
        {
            throw new NotImplementedException();
        }
    }
}
