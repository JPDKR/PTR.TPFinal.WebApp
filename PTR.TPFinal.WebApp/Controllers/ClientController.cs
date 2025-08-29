using Microsoft.AspNetCore.Mvc;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;
using PTR.TPFinal.Services.Interfaces;

namespace PTR.TPFinal.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(IClientService clientService) : ControllerBase
    {
        private readonly IClientService _clientService = clientService;

        [HttpGet]
        public IActionResult GetAll()
        {
            var Clients = _clientService.GetAll();
            return Ok(Clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Client = _clientService.GetById(id);
            if (Client is null) return NotFound();
            return Ok(Client);
        }

        [HttpPost]
        public IActionResult Create(CreateClientRequestDto request)
        {
            var newClient = _clientService.Create(request);
            return Ok(newClient);
        }

        [HttpDelete]
        public IActionResult DeleteClient(int id)
        {
            _clientService.Delete(id);
            return Ok();
        }
    }
}
