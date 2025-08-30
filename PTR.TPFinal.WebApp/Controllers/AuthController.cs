using Microsoft.AspNetCore.Mvc;
using PTR.TPFinal.Domain.Auth;
using PTR.TPFinal.Services.Interfaces;

namespace PTR.TPFinal.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ITokenService tokenService, IClientService clientService) : ControllerBase
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly IClientService _clientService = clientService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationRequestDto authDto)
        {
            var client = await _clientService.Authenticate(authDto);

            if (client == null) return Unauthorized("Usuario o contraseña incorrectos.");

            var token = _tokenService.GenerateToken(client.ECommerceName);

            return Ok(token);
        }
    }
}