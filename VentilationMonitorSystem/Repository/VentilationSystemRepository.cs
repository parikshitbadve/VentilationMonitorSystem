using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using VentilationMonitorSystem.Data;
using VentilationMonitorSystem.Models;
using VentilationMonitorSystem.Repository.IRepository;

namespace VentilationMonitorSystem.Repository
{
  
    public class VentilationSystemRepository : IVentilationSystemRepository
    {
        private readonly ApplicationDbContext _db;
        public VentilationSystemRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateVentilationSystem(VentilationMonitorDto ventilationMonitor)
        {
            _db.VentilationDetail.Add(ventilationMonitor);
            return Save();
        }

        public bool DeleteVentilationSystem(VentilationMonitorDto ventilationMonitor)
        {
            VentilationMonitorDto record =_db.VentilationDetail.Where(x=>x.RecordId==ventilationMonitor.RecordId).FirstOrDefault();
            record.IsActive = false;
            return Save();
        }

        public VentilationMonitorDto GetVentilationSystem(Guid recordId)
        {
            return _db.VentilationDetail.FirstOrDefault(x => x.RecordId == recordId && x.IsActive==true);
        }

        public ICollection<VentilationMonitorDto> GetVentilationSystems()
        {
            return _db.VentilationDetail.Where(x => x.IsActive==true).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateVentilationSystem(VentilationMonitorDto ventilationMonitor)
        {
            _db.VentilationDetail.Update(ventilationMonitor);
            return Save();
        }

        public bool VentilationSystemExists(Guid recordId)
        {
            bool value = _db.VentilationDetail.Any(x => x.RecordId == recordId && x.IsActive == true);
            return value;
        }
    }
}
