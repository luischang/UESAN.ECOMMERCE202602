using Microsoft.AspNetCore.Mvc;
using UESAN.ECOMMERCE.CORE.Core.DTOs;
using UESAN.ECOMMERCE.CORE.Core.Interfaces;

namespace UESAN.ECOMMERCE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequestDTO signIn)
        {
            var result = await _userService.SignIn(signIn);
            if (result == null) return Unauthorized();
            return Ok(result);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestDTO signUp)
        {
            var created = await _userService.SignUp(signUp);
            if (!created) return BadRequest();
            return Created(string.Empty, null);
        }
    }
}
