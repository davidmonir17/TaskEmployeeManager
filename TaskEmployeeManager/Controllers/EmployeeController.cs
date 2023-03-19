using Domain.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskEmployeeManager.Controllers
{
    [Authorize(Roles = "Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceManager service;

        public EmployeeController(IServiceManager service)
        {
            this.service = service;
        }

        [HttpGet("{Id}")]
        public IActionResult getEmployeeTasks(int Id)
        {
            //throw new Exception("Exception");
            var tasks = service.employeeService.GetTasks(Id);
            if (tasks == null)
            {
                return BadRequest("invalid employee Id Or not have tasks");
            }
            return Ok(tasks);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateEmpTask([FromBody] UpdateEmpTaskDTO taskDTO, int Id)
        {
            var task = service.employeeService.UpdateTask(Id, taskDTO);
            if (task == null)
            {
                return BadRequest("invalid employee Id Or not have tasks");
            }
            return Ok(task);
        }
    }
}