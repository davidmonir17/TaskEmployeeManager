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

        [HttpGet("{MgrId}")]
        public IActionResult GetemployeesforMgr(int MgrId)
        {
            if (MgrId == 0)
            {
                return BadRequest("Invalid Manager Id");
            }
            var cheack = service.ManagerService.checkMangerDep(MgrId);
            if (!cheack)
            {
                return BadRequest("that Manger Id not is Manager of any depertment ");
            }
            var emps = service.ManagerService.GeteallEmps(MgrId);
            if (emps == null)
            {
                return BadRequest("Invalid Manager Id");
            }
            return Ok(emps);
        }

        [HttpDelete("{MgrId}/employee/{empId}")]
        public IActionResult DeleteEmployee(int MgrId, int empId)
        {
            if (MgrId == 0)
            {
                return BadRequest("Invalid Manager Id");
            }
            var cheack = service.ManagerService.checkMangerDep(MgrId);
            if (!cheack)
            {
                return BadRequest("that Manger Id not is Manager of any depertment ");
            }
            var deleted = service.ManagerService.DeleteEmployee(MgrId, empId);
            if (!deleted)
            {
                return BadRequest("Failed For Delete Employee");
            }
            return NoContent();
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
            var cheack = service.ManagerService.checkMangerDep(MgrId);
            if (!cheack)
            {
                return BadRequest("that Manger Id not is Manager of any depertment ");
            }
            var empdetail = service.ManagerService.addNewEmployee(MgrId, employee);
            if (empdetail == null)
            {
                return BadRequest("Failed in creation");
            }
            return Ok(empdetail);
        }

        [HttpPut("{MgrId}")]
        public IActionResult UpdateEmployee(int MgrId, [FromBody] mgrUpdEmpDto empDto)
        {
            if (MgrId == 0)
            {
                return BadRequest("Invalid Manager Id");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid employee spesifec");
            }
            var cheack = service.ManagerService.checkMangerDep(MgrId);
            if (!cheack)
            {
                return BadRequest("that Manger Id not is Manager of any depertment ");
            }
            var employee = service.ManagerService.updateEmployee(MgrId, empDto);
            if (employee == null)
            {
                return BadRequest("Failed in Updating");
            }
            return Ok(employee);
        }
    }
}