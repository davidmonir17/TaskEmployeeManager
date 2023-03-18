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
                return NotFound();
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
                return NotFound("Failed For Delete Employee");
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
                return NotFound("Failed in creation");
            }
            return Ok(empdetail);
        }

        [Route("Delete-Task/{MgrId}")]
        [HttpDelete]
        public IActionResult DeleteTask(int MgrId, [FromQuery] int TaskId)
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
            var che = service.ManagerService.DeleteTaskForMgr(MgrId, TaskId);
            if (!che)
            {
                return NotFound("Failed To Delete");
            }
            return NoContent();
        }

        [HttpGet("{MgrId}/GetAllTasks")]
        public IActionResult GetAllTasks(int MgrId, [FromQuery] int statues)
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
            var tasks = service.ManagerService.GetAlltasks(MgrId, statues);
            if (tasks == null)
            {
                return NotFound();
            }
            return Ok(tasks);
        }

        [HttpGet("{MgrId}/employee/{empId}/GetAllTasksForEmployye")]
        public IActionResult GetAllTasksForEmployye(int MgrId, int empId, [FromQuery] int statues)
        {
            if (MgrId == 0 || empId == 0)
            {
                return BadRequest("Invalid Manager Id Or Invalid Employee Id");
            }
            var cheack = service.ManagerService.checkMangerDep(MgrId);
            if (!cheack)
            {
                return BadRequest("that Manger Id not is Manager of any depertment ");
            }
            var tasks = service.ManagerService.GetAlltasksForEmp(MgrId, empId, statues);
            if (tasks == null)
            {
                return NotFound();
            }
            return Ok(tasks);
        }

        [HttpPost("{MgrId}/employee/{empId}/AddtaskToEmployee")]
        public IActionResult AddtaskToEmployee(int MgrId, int empId, [FromBody] MgrAddTaskDto taskDto)
        {
            if (MgrId == 0 || empId == 0)
            {
                return BadRequest("Invalid Manager Id Or Invalid Employee Id");
            }
            var cheack = service.ManagerService.checkMangerDep(MgrId);
            if (!cheack)
            {
                return BadRequest("that Manger Id not is Manager of any depertment ");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid employee spesifec");
            }
            var task = service.ManagerService.AddtaskToEmp(MgrId, empId, taskDto);
            if (task == null)
            {
                return NotFound("Failed to add Task");
            }
            return Ok(task);
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
                return NotFound("Failed in Updating");
            }
            return Ok(employee);
        }

        [Route("Update-Task/{MgrId}")]
        [HttpPut]
        public IActionResult UpdateTaskForMgr(int MgrId, [FromBody] MgrUpdTaskDto taskdto)
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
            var task = service.ManagerService.updateTask(MgrId, taskdto);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [Route("ReAssign-Task/{MgrId}")]
        [HttpPut]
        public IActionResult ReAssignTaskForMgr(int MgrId, [FromQuery] int TaskId, [FromQuery] int NewEmpId)
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
            var task = service.ManagerService.ReAssignTask(MgrId, TaskId, NewEmpId);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
    }
}