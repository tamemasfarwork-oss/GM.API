using GM.BLL.DTOs.Authdto;
using GM.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    private readonly IUserService _service;

    public AuthController(IAuthService auth, IUserService service)
    {
        _auth = auth;
        _service = service;
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto dto)
    {
        var result = await _auth.LoginAsync(dto);
        if (result is null)
            return Unauthorized(new { message = "Invalid email or password" });

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> Register(CreateUserDto dto)
    {
        var error = await _service.RegisterAsync(dto);

        if (error == "EMAIL_EXISTS")
            return Conflict(new { message = "Email already exists" });

        return Ok(new { message = "Account request received. Waiting for approval." });
    }
}