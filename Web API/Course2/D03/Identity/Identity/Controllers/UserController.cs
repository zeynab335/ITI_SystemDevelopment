using Identity.Data.Contexy;
using Identity.Data.Models;
using Identity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<Manager> _userManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<Manager> userManager , IConfiguration configuration ) {
            _userManager = userManager;
            _configuration = configuration;
            
        }

        // register For Admin
        [HttpPost]
        [Route("RegisterForAdmin")]
        public async Task<ActionResult> AdminRegister(RegisterDto registerDto)
        {
            var Admin = new Manager
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Department = registerDto.Department
            };

            // create new user identity
            var result = await _userManager.CreateAsync(Admin, registerDto.Password);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            // create Claims
            var Claims = new List<Claim>
            {
                // Admin.Id ==> get this id after creating user Identity
                new Claim(ClaimTypes.NameIdentifier , Admin.Id),
                new Claim(ClaimTypes.Role , "Admin")
            };

            // add claims into userMAnager
            await _userManager.AddClaimsAsync(Admin , Claims);
            return NoContent();


        }


        // register For User
        [HttpPost]
        [Route("RegisterForUser")]
        public async Task<ActionResult> UserRegister(RegisterDto registerDto)
        {
            var User = new Manager
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Department = registerDto.Department
            };

            // create new user identity
            var result = await _userManager.CreateAsync(User, registerDto.Password);
            
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            
            // create Claims
            var Claims = new List<Claim>
            {
                // Admin.Id ==> get this id after creating user Identity
                new Claim(ClaimTypes.NameIdentifier , User.Id),
                new Claim(ClaimTypes.Role , "User")
            };

            // add claims into userMAnager
            await _userManager.AddClaimsAsync(User, Claims);
            return NoContent();

        }


        // Login
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDTO>> Login (LoginDTO credentials)
        {
            // check if user name exsist ot not
            var user = await _userManager.FindByNameAsync(credentials.UserName);
            if (user == null)
            {
                return NotFound();
            }

            // check if password is matched or not
            var isAuthenticated = await _userManager.CheckPasswordAsync(user, credentials.Password);
            if (!isAuthenticated)
            {
                return Unauthorized();
            }

            // get claims of user to make JWT
            var claims  = await _userManager.GetClaimsAsync(user);

            // get screte key to pass to JWT
            var secreteKeyString = _configuration.GetValue<string>("SecretKey")??string.Empty;
            var secreteKeyInBytes = Encoding.ASCII.GetBytes(secreteKeyString);
            var SymmetricSecretKey = new SymmetricSecurityKey(secreteKeyInBytes);

            // create Combination of SecretKey, HashingAlgorithm
            var siginingCreedentials = new SigningCredentials(SymmetricSecretKey
                , SecurityAlgorithms.HmacSha256Signature);

            DateTime expiry = DateTime.Now.AddDays(1);

            // create new instance from JWT
            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiry,
                signingCredentials: siginingCreedentials
             );


            // get token string
            var TokenHandler = new JwtSecurityTokenHandler();
            var TokentString = TokenHandler.WriteToken(token);

            return new TokenDTO(TokentString, expiry); 



        }
    }
}
