using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.Interfaces;

namespace PTR.TPFinal.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpGet]
        public IActionResult GetAll()
        {
            var Clients = _productService.GetAll();
            return Ok(Clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Client = _productService.GetById(id);
            if (Client is null) return NotFound();
            return Ok(Client);
        }

        [HttpPost]
        public IActionResult Create(CreateProductRequestDto request)
        {
            var newClient = _productService.Create(request);
            return Ok(newClient);
        }

        [HttpDelete]
        public IActionResult DeleteClient(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}