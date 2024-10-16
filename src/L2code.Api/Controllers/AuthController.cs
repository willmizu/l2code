using L2code.Domain.Interfaces;
using L2code.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace L2code.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _auth;

        public AuthController(IAuthenticationService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var response = _auth.GenerateToken(user);

            return response.StatusCode == StatusCodes.Status200OK ? Ok(response) : Unauthorized();
        }
    }
}