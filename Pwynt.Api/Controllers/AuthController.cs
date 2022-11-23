using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pwynt.Core.Dtos;
using Pwynt.Core.Interfaces;

namespace Pwynt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(registerDto);

            if(!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
