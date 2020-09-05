using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentilationMonitorSystem.Models
{
    public class VentilationMonitorDto
    {
        [Key]
        public System.Guid RecordId { get; set; }

        [Required]
        public System.Guid unitId { get; set; }

        [Required]
        public int LongWall { get; set; }

      //  [Required]
        public int Taligate { get; set; }

        //[Required]
        public int MG13 { get; set; }

        [Required]
        public int MG14 { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } 

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
