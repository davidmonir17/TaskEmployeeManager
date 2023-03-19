using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Implmentation;
using Services.Interface;
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

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.authService.RegisterAsync(model, "Admin");

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [Route("Add-Manager")]
        [HttpPost]
        public async Task<IActionResult> AddManager([FromBody] addMngrDto manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid manager spesifec");
            }
            string[] parts = manager.Email.Split('@');

            var model = new RegisterModel
            {
                Name = manager.Name,
                Email = manager.Email,
                Username = parts[0],
                Password = parts[0] + "@1234A"
            };
            var result = await service.authService.RegisterAsync(model, "Manager");
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            var mgr = service.adminService.addMnager(manager);
            if (mgr == null)
            {
                return BadRequest("the depertment Not found Or depertment has al ready Mnager");
            }
            service.emailService.SendEmail(manager.Email, "Congratues You is new manager with this mail and password", "A new Password: " + parts[0] + "@1234A");
            return Ok(mgr);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("SendEmail")]
        public IActionResult SendEmail([FromForm] string toAddress, [FromForm] string subject, [FromForm] string body)
        {
            service.emailService.SendEmail(toAddress, subject, body);

            return Ok();
        }
    }
}