﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentilationMonitorSystem.Models
{
    public class UnitModel
    {
        [Key]
        public System.Guid UnitId { get; set; }

        [Required]
        public string UnitName { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
