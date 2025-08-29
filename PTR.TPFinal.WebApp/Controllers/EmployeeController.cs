using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.Interfaces;

namespace PTR.TPFinal.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;

        [HttpGet]
        public IActionResult GetAll()
        {
            var Clients = _employeeService.GetAll();
            return Ok(Clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Client = _employeeService.GetById(id);
            if (Client is null) return NotFound();
            return Ok(Client);
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeRequestDto request)
        {
            var newClient = _employeeService.Create(request);
            return Ok(newClient);
        }

        [HttpDelete]
        public IActionResult DeleteClient(int id)
        {
            _employeeService.Delete(id);
            return Ok();
        }
    }
}
