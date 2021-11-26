using hr.api.Utils;
using hr_system_v2.Application.DTOs;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;
using hr_system_v2.Utils;
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
using System.Net;
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
        private readonly IResetPasswordRepository _repo;
        private readonly IUnitOfWork _uow;
        public LoginController(UserManager<ApplicationUser> userManager, IJWT jwt, IResetPasswordRepository repo, IUnitOfWork uow)
        {
            _userManager = userManager;
            _jwt = jwt;
            _repo = repo;
            _uow = uow;
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
            else
            {
                return BadRequest("Usuário não existente");
            }
        }

        [HttpPost("sentEmail")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SentEmail([FromBody] string email)
        {
            Random rnd = new Random();

            var user = await _userManager.FindByNameAsync(email);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            int otp = rnd.Next();

            var reset = new ResetPassword()
            {   
                Id = Guid.NewGuid(),
                Email = email,
                OTP = otp.ToString(),
                InsertDateTimeUTC = DateTime.UtcNow,
                UserId = Guid.Parse(user.Id),
                Token = token
            };

            _repo.Add(reset);
            _uow.Commit();

            EmailSender emailSender = new EmailSender();
            emailSender.SendEmail(email, otp.ToString());

            return Ok();
        }


        [HttpPost("resetPassword")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PasswordReset([FromBody] ResetPasswordDTO resetPassword)
        {
            if (resetPassword.Email == null || resetPassword.OTP == null || resetPassword.Password == null)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByNameAsync(resetPassword.Email);

            var list = _repo.List().ToList();

            var resetTokenDetails = list.Where(rp => rp.OTP == resetPassword.OTP && rp.UserId == Guid.Parse(user.Id)).FirstOrDefault();
            var expiration = resetTokenDetails.InsertDateTimeUTC.AddMinutes(15);

            if (expiration < DateTime.UtcNow)
                return BadRequest("Invalid Token");

            await _userManager.ResetPasswordAsync(user, resetTokenDetails.Token, resetPassword.Password);

            return Ok();
        }
    }
}
