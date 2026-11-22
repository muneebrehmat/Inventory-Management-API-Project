using InventoryManagement_API.DTOS.AuthDTOS;
using InventoryManagement_API.Services.Intrerfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDto registrationDto)
        {
            var result = await _authServices.CreateUserAsync(registrationDto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var token = await _authServices.LoginUserAsync(loginDto);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
