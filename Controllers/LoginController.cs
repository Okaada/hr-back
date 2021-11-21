using hr.api.Utils;
using hr_system_v2.Application.DTOs;
using hr_system_v2.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hr_system_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJWT _jwt;
        public LoginController(UserManager<ApplicationUser> userManager, IJWT jwt)
        {
            _userManager = userManager;
            _jwt = jwt;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO user)
        {

            var userName = await _userManager.FindByNameAsync(user.UserName);
            var isChecked = await _userManager.CheckPasswordAsync(userName, user.Password);

            if (user == null)
            {
                return BadRequest("Request do cliente inválido");
            }
            if (isChecked)
            {
                string tokenString = _jwt.ReturnToken();
                return Ok(new { Token = tokenString });
            }
            else{
                return BadRequest("Usuário não existente");
            }
        }
    }
}
