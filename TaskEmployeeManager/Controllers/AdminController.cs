using Domain.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskEmployeeManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IServiceManager service;

        public AdminController(IServiceManager service)
        {
            this.service = service;
        }

        [Route("add-Depertment")]
        [HttpPost]
        public IActionResult addDepertment([FromBody] AddDepDTo depDTo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid depertment spesifec");
            }
            var depertment = service.adminService.addDepertment(depDTo);
            return Ok(depertment);
        }

        [Route("Add-Manager")]
        [HttpPost]
        public IActionResult AddManager([FromBody] addMngrDto manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid manager spesifec");
            }
            var mgr = service.adminService.addMnager(manager);
            if (mgr == null)
            {
                return BadRequest("the depertment Not found Or depertment has al ready Mnager");
            }
            return Ok(mgr);
        }
    }
}