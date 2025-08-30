using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.Interfaces;

namespace PTR.TPFinal.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ShoppingCartController(IShoppingCartService shoppingCartService) : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService = shoppingCartService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var ShoppingCart = await _shoppingCartService.GetByIdAsync(id);
            if (ShoppingCart == null) return NotFound();
            return Ok(ShoppingCart);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string fieldName, string fieldValue)
        {
            var ShoppingCarts = await _shoppingCartService.GetAllAsync(fieldName, fieldValue);
            return Ok(ShoppingCarts);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ShoppingCart ShoppingCart)
        {
            var success = await _shoppingCartService.UpdateAsync(ShoppingCart, id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _shoppingCartService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShoppingCartRequestDto ShoppingCart)
        {
            var totalPrice = await _shoppingCartService.AddToShoppingCartAsync(ShoppingCart);
            return Ok(totalPrice);
        }
    }
}
