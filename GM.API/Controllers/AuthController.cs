using GM.BLL.DTOs.UserDto;
using GM.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        readonly private IUserService _userService;

       public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult>  Register(UserDto userDto)
        {
            var result = await _userService.Register(userDto);
            if(result != false) 
              
            return Ok("User registered successfully.");
            else
                return BadRequest();
        }
    }
}
