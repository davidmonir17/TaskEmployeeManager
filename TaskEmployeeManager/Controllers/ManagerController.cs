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
    public class ManagerController : ControllerBase
    {
        private readonly IServiceManager service;

        public ManagerController(IServiceManager service)
        {
            this.service = service;
        }

        [HttpPost("{MgrId}")]
        public IActionResult AddEmployee(int MgrId, [FromBody] mgrAddEmp employee)
        {
            if (MgrId == 0)
            {
                return BadRequest("Invalid Manager Id");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid employee spesifec");
            }
            var empdetail = service.ManagerService.addNewEmployee(MgrId, employee);
            if (empdetail == null)
            {
                return BadRequest("Failed in creation");
            }
            return Ok(empdetail);
        }
    }
}