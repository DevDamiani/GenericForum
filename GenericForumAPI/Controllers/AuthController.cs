using GenericForum.Model.Interfaces.Services;
using GenericForum.Model.Request;
using Microsoft.AspNetCore.Mvc;


namespace GenericForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private IAuthService _authService { get; }

        public AuthController(IAuthService auth)
        {
            _authService = auth;
            
        }

        // POST api/Auth
        [HttpPost()]
        public IActionResult AuthClient([FromBody] ClientLoginRequest value)
        {

            var token = _authService.AuthClient(value);

            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { message = "user or password invalid" });

            Response.Headers.Add("x-access-token", token);

            return Ok();

        }

        [ValidateAntiForgeryToken]
        [HttpGet]
        public IActionResult ValidToken()
        {

            return Ok();

        }
    }
}
