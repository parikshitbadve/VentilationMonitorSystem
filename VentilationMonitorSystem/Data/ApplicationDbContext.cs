using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentilationMonitorSystem.Models;

namespace VentilationMonitorSystem.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public DbSet<DepartmentModel> Department { get; set; }

        public DbSet<VentilationMonitorModel> VentilationDetail { get; set; }

        public DbSet<UnitModel> units { get; set; }
    }
}
