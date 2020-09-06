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
        public UnitModel CreateUnit(string unitName)
        {
            UnitModel model = new UnitModel()
            {
                UnitId = new Guid(),
                UnitName = unitName,
                IsActive = true

            };
            _db.units.Add(model);
            Save();

            return model;
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
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool unitExists(string unitName)
        {
            bool value = _db.units.Any(x => x.UnitName == unitName && x.IsActive == true);
            return value;
        }

        public bool UpdateUnit(UnitModel ventilationMonitor)
        {
            throw new NotImplementedException();
        }
    }
}
