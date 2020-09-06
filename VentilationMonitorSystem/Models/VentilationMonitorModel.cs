using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VentilationMonitorSystem.Models
{
    public class VentilationMonitorModel
    {
        [Key]
        public System.Guid RecordId { get; set; }

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

       [Required]
        public System.Guid UnitId { get; set; }

        [NotMapped]
        public string Unit { get; set; }

        [ForeignKey("UnitId")]

        public UnitModel Units { get; set; }
    }
}
