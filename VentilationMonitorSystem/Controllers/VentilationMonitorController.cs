using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using VentilationMonitorSystem.Models;
using VentilationMonitorSystem.Repository.IRepository;

namespace VentilationMonitorSystem.Controllers
{
    public class VentilationMonitorController : Controller
    {
        private readonly IVentilationSystemRepository _vmRepo;
        private readonly IUnitsRepository _unRepo;
        private readonly IMapper _mapper;

        public VentilationMonitorController(IVentilationSystemRepository vmRepo, IUnitsRepository unRepo,IMapper mapper)
        {
            _vmRepo = vmRepo;
            _mapper = mapper;
            _unRepo = unRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

       

        /// <summary>
        /// Get List of VentilationMonitor
        /// </summary>
       
        public IActionResult  GetVentilationMonitorData()
        {
            try
            {

                var objList = _vmRepo.GetVentilationSystems();
                var objDto = new List<VentilationMonitorDto>();
                foreach (var obj in objList)
                {
                    objDto.Add(_mapper.Map<VentilationMonitorDto>(obj));
                }
                var objDepartMentList = _vmRepo.GetDepartments();
                var objDeptDto = new List<DepartmentDto>();
                foreach (var obj in objDepartMentList)
                {
                    objDeptDto.Add(_mapper.Map<DepartmentDto>(obj));
                }
                return Json(new { data = objList,data1=objDeptDto });
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }

        }

        /// <summary>
        /// Add VentilationMonitor Record
        /// </summary>
      
        public IActionResult AddRecord(VentilationMonitorDto data)
        {
            try
            {
                
               var model = _mapper.Map<VentilationMonitorModel>(data);

                // Check If Unit Exist
                var value = _unRepo.unitExists(data.Unit);
                if (!value)
                {
                    // Insert Data in Unit table
                    var objUnit = _unRepo.CreateUnit(data.Unit);
                    model.UnitId = objUnit.UnitId;
                    var status = _vmRepo.CreateVentilationSystem(model);
                    if (status)
                    {

                        return Json(new { success = true, message = "Record Added succesfully" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Something went wrong.Please try again later!" });
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Record already exists!" });
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
        }

        /// <summary>
        /// Delete VentilationMonitor Record
        /// </summary>
        
        [HttpDelete]
        public IActionResult RemoveRecord(System.Guid? id)
        {
            try
            {
                var status = _vmRepo.DeleteVentilationSystem(id.GetValueOrDefault());
                if (status)
                {
                    
                    return Json(new { success = true, message = "Record deleted succesfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Something went wrong.Please try again later!" });
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }

        }
    }
}
