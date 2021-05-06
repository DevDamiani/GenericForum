using GenericForum.Model.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GenericForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        private IProfileService _profileService { get; set; }

        public ProfileController(IProfileService profile)
        {
            _profileService = profile;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetProfileByID(int id)
        {

            var profileResponse = _profileService.GetProfileByID(id);

            if (profileResponse == null)
                return NotFound();

            return Ok(profileResponse);
        }


        //[HttpPut]
        //public IActionResult EditProfile()
        //{
        //    throw new NotImplementedException();
        //}

    }
}
