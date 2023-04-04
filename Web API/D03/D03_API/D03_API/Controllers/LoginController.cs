using D03_API.Context;
using D03_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace D03_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
       APIContext _context;
        public LoginController(APIContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            Instructor ins = _context.Instructors.Where(n => n.Email == email && n.Password == password).FirstOrDefault();
            if (ins != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Signiture_Key_123"));

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var data = new List<Claim>();
                data.Add(new Claim("name", ins.Name));

                var token = new JwtSecurityToken(

                claims: data,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));

            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
