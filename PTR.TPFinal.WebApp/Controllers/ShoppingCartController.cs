using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.Interfaces;

namespace PTR.TPFinal.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShoppingCartController(IShoppingCartService shoppingCartService) : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService = shoppingCartService;

        [HttpGet]
        public IActionResult GetAll()
        {
            var Clients = _shoppingCartService.GetAll();
            return Ok(Clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Client = _shoppingCartService.GetById(id);
            if (Client is null) return NotFound();
            return Ok(Client);
        }

        [HttpPost]
        public IActionResult Create(CreateShoppingCartRequestDto request)
        {
            var newClient = _shoppingCartService.Create(request);
            return Ok(newClient);
        }

        [HttpDelete]
        public IActionResult DeleteClient(int id)
        {
            _shoppingCartService.Delete(id);
            return Ok();
        }
    }
}
