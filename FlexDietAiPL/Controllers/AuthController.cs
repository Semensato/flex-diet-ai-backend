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

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] RegisterRequestDto registerRequest)
        {
            try
            {
                UserDto newUser = registerRequest.User;

                var user = await _userService.AddUserAsync(new User { 
                    Email = newUser.Email,
                    BashPassword = newUser.BashPassword,
                    CreationDate = DateTime.UtcNow,
                    UserData = newUser.UserData is not null 
                    ? new UserData
                    {
                        Name = newUser.UserData.Name,
                        LastName = newUser.UserData.LastName,
                        Dof = newUser.UserData.Dof,
                        Somatotype = newUser.UserData.Somatotype,
                    } : null
                });

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
