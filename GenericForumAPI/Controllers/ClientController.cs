using GenericForum.Model.Interfaces.Services;
using GenericForum.Model.Request;
using Microsoft.AspNetCore.Mvc;


namespace GenericForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private IClientService _userService { get; }

        public ClientController(IClientService userService)
        {
            _userService = userService;
        }

        // POST api/user/usernameverify
        [HttpPost("usernameistaken")]
        public bool UserNameIsTaken([FromBody]ClientUserNameRequest data) => 
            _userService.UserNameIsTaken(data);

          
        // POST api/user/createuser
        [HttpPost("create")]
        public IActionResult CreateClient([FromBody] CreateClientRequest data)
        {

            var isCreate = _userService.CreateClient(data);

            if (!isCreate)
                return BadRequest("UserName invalid");

            return Ok();
        }

    }
}
