using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using VentilationMonitorSystem.Repository.IRepository;

namespace VentilationMonitorSystem.Controllers
{
    public class VentilationMonitorController : Controller
    {
        private readonly IVentilationSystemRepository _vmRepo;

        public VentilationMonitorController(IVentilationSystemRepository vmRepo)
        {
            _vmRepo = vmRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
