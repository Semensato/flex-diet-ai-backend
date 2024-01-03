using FlexDietAiBAL.Services;
using FlexDietAiDAL.Models;
using FlexDietAiPL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlexDietAiPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly JWTService _jwtService;

        public AuthController(UserService userService, JWTService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequestDto loginRequest)
        {
            try
            {
                var user = await _userService.GetUserByLoginAsync(loginRequest.User.Email, loginRequest.User.BashPassword);
                
                if(user is not null)
                {
                    var roles = new List<string> { "user" };
                    var token = _jwtService.GenerateToken(user, roles);

                    return Ok(new { Token = token });
                }

                return Unauthorized();

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Unauthorized();
            }
        }
    }
}
