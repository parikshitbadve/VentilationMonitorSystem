using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentilationMonitorSystem.Models
{
    public class DepartmentDto
    {
        [Key]

        public System.Guid DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public int VentilationCapacity { get; set; }

    }
}
