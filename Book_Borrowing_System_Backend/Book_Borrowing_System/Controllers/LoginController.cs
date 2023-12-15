using Business_Logic_Layer.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Book_Borrowing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService authService)
        {
            _loginService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Authenticate([FromBody] LoginDTO model)
        {
            if (model == null)
            {
                return BadRequest(new { Message = "Invalid request body." });
            }

            var user = await _loginService.ValidateUserCredentials(model.Username, model.Password);

            if (user != null)
            {
                var token = _loginService.GenerateJwtToken(user);
                return Ok(new { Token = token });
            }
            return Unauthorized(new { Message = "Invalid credentials" });
        }
    }
}
