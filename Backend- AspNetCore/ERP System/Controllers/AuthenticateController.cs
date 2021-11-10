using ERP_System.Models.HR.UsersAccounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<Employee_UserAccount> User_Manager;
        private readonly RoleManager<IdentityRole> Role_Manager;
        private readonly IConfiguration config ;
        private readonly ILogger logger;
        public AuthenticateController(UserManager <Employee_UserAccount> User_Manager_,RoleManager<IdentityRole> Role_Manager_
            ,IConfiguration config_,ILogger<AuthenticateController>logger_)
        {
            User_Manager = User_Manager_;
            Role_Manager = Role_Manager_;
            config = config_;
            logger = logger_;
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> login([FromBody] LoginModel model)
        {
            var employee_useraccount =await User_Manager.FindByNameAsync(model.UserName);
            if (employee_useraccount != null && await User_Manager.CheckPasswordAsync(employee_useraccount, model.Password))
            {
                var user_roles = await User_Manager.GetRolesAsync(employee_useraccount);
                var authclaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,employee_useraccount.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
                var token = new JwtSecurityToken(
                    issuer: config["Jwt:Issuer"],
                    audience: config["Jwt:Audience"],
                    claims: authclaims,
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token).ToString(),
                    expiration = token.ValidTo
                });

            }
            else return Unauthorized();
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await User_Manager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new  { Status = "Error", Message = "User already exists!" });

            Employee_UserAccount user = new Employee_UserAccount()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await User_Manager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new  { Status = "Error", Message = result.Errors});

            return Ok(new  { Status = "Success", Message = "User created successfully!" });
        }


    }
}
