using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Configuration;
using System.Text;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {

        public UserManager<IdentityUser> userManager { get; set; }

        public LoginApiController(UserManager<IdentityUser> userManager)
        {
            this.userManager=userManager;
        }

        // POST api/<LoginApiController>
        [HttpPost]
        public async Task<string> PostAsync(MyLoginModel login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);

            if (user != null)
            {
                var result = userManager.CheckPasswordAsync(user, login.Password);
                if (await result)
                {
                    var userClaims = await userManager.GetClaimsAsync(user);
                    var roles = await userManager.GetRolesAsync(user);
                    var roleClaims = new List<Claim>();
                    for (int i = 0; i < roles.Count; i++)
                    {
                        roleClaims.Add(new Claim("roles", roles[i]));
                    }
                    var claims = new[]
                    {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
                    .Union(userClaims)
                    .Union(roleClaims);

                    string jwtKey = "C1CF4B7DC4C4175B6618DE4F55CA4";
                    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
                    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
                    var jwtSecurityToken = new JwtSecurityToken(
                        issuer: "MyApi",
                        audience: "My Audience",
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        signingCredentials: signingCredentials
                        );

                    var jwtsecurityTokenHandler = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                    return jwtsecurityTokenHandler;
                }
                { return "wrong username or password"; }
            }
            else
            {
                return "wrong username or password";
            }
        }

       
    }

   
}
