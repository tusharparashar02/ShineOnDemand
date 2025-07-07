using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTO;
using Backend.DTO.User;
using Backend.MiddleWare;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly JwtToken tokenService;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            JwtToken tokenService
        )
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (registerDTO.Role.ToUpper() == "CUSTOMER" || registerDTO.Role.ToUpper() == "WASHER" || registerDTO.Role.ToUpper() == "ADMIN"){}
            else
            {
                return BadRequest("Select a valid role");
            }
            if (await userManager.FindByEmailAsync(registerDTO.Email) != null)
            {
                return BadRequest("User already exist");
            }
            var user = new ApplicationUser
            {
                UserName = registerDTO.Name,
                Email = registerDTO.Email,
            };
            var result = await userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            if (!await roleManager.RoleExistsAsync(registerDTO.Role.ToUpper()))
                await roleManager.CreateAsync(new IdentityRole(registerDTO.Role.ToUpper()));

            await userManager.AddToRoleAsync(user, registerDTO.Role.ToUpper());
            var response = new ResponseDTO<object> { Success = true, Message = "User registered successfully" };
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                return Unauthorized("Invalid credentials");
            }
            var token = await tokenService.CreateTokenAsync(user);
            return Ok(new { Token = token });
        }
    }
}
