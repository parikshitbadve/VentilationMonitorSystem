using Microsoft.EntityFrameworkCore;
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
        public bool CreateVentilationSystem(VentilationMonitorModel ventilationMonitor)
        {
            ventilationMonitor.RecordId = new Guid();
            ventilationMonitor.CreatedDate = DateTime.Now;
            ventilationMonitor.IsActive = true;
            _db.VentilationDetail.Add(ventilationMonitor);
            return Save();
        }

        public bool DeleteVentilationSystem(System.Guid recordId)
        {
            VentilationMonitorModel record =_db.VentilationDetail.Where(x=>x.RecordId== recordId).FirstOrDefault();
            record.IsActive = false;
            return Save();
        }

        public ICollection<DepartmentModel> GetDepartments()
        {
            return _db.Department.ToList();
        }

        public VentilationMonitorModel GetVentilationSystem(Guid recordId)
        {
            var ventilationData = _db.VentilationDetail.Where(x=>x.RecordId==recordId).Include(r => r.Units).FirstOrDefault();
            return _db.VentilationDetail.FirstOrDefault(x => x.RecordId == recordId && x.IsActive==true);
        }

        public ICollection<VentilationMonitorModel> GetVentilationSystems()
        {
            List<VentilationMonitorModel> model = new List<VentilationMonitorModel>();
            var ventilationData = _db.VentilationDetail.Where(x => x.IsActive == true).Include(r => r.Units);
            foreach (VentilationMonitorModel item in ventilationData)
            {
                item.Unit = item.Units.UnitName;
                 model.Add(item);
            }
            return model;
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateVentilationSystem(VentilationMonitorModel ventilationMonitor)
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
