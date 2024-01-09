using FlexDietAiBAL.Services;
using FlexDietAiDAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlexDietAiPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            try
            {
                await _userService.AddUserAsync(user);
                return Ok(user);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                List<User> users = (List<User>)await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetById(Guid Id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(Id);
                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
