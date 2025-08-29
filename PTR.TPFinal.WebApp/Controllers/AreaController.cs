using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.Interfaces;

namespace PTR.TPFinal.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AreaController(IAreaService areaService) : ControllerBase
    {
        private readonly IAreaService _areaService = areaService;

        [HttpGet]
        public IActionResult GetAll()
        {
            var Clients = _areaService.GetAll();
            return Ok(Clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Client = _areaService.GetById(id);
            if (Client is null) return NotFound();
            return Ok(Client);
        }

        [HttpPost]
        public IActionResult Create(CreateAreaRequestDto request)
        {
            var newClient = _areaService.Create(request);
            return Ok(newClient);
        }

        [HttpDelete]
        public IActionResult DeleteClient(int id)
        {
            _areaService.Delete(id);
            return Ok();
        }
    }
}
