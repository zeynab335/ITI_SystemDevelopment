using Identity.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly UserManager<Manager> _userManager;

        public DataController(UserManager<Manager> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetUseInfo()
        {
            var user = await _userManager.GetUserAsync(User);

            if(user == null)
            {
                return NotFound();
            }
            return Ok(new{UseName = user.UserName  , Email = user.Email , Department=user.Department  });
        }


        [HttpGet]
        [Authorize(Policy = "User")]
        [Route("User")]

        public ActionResult GetDataForUsers()
        {
            return Ok(new { Data = "This data is secured for users" });
        }


        [HttpGet]
        [Authorize(Policy = "Admin")]
        [Route("Admin")]

        public ActionResult GetDataForAdmin()
        {
            return Ok(new { Data = "This data is secured for Admin" });
        }
    }
}
