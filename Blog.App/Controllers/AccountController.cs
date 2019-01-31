using AutoMapper;
using Blog.App.ViewModels;
using Blog.Data;
using Blog.Data.Entities;
using Microsoft.AspNetCore.Authorization;
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

namespace Blog.App.Controllers
{
    [Route("api/auth/[action]")]
    [ApiController]
    public partial class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly BlogDbContext db;
        private readonly IMapper mapper;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            BlogDbContext db,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            this.db = db;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<object> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var user = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                return await GenerateJwtToken(user);
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }

        [HttpPost]
        public async Task<object> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = mapper.Map<RegisterViewModel, ApplicationUser>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "user").Wait();

                await _signInManager.SignInAsync(user, false);
                return await GenerateJwtToken(user);
            }

            throw new ApplicationException("REGISTER_FAILED");
        }

        [Authorize]
        [HttpPost]
        public async Task<object> ChangePassword(ChangePasswordViewModel model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = db.Users.Find(userId);

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                return await GenerateJwtToken(user);
            }

            throw new ApplicationException("PASSWORD_CHANGE_FAILED");
        }

        private async Task<object> GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("id", user.Id)
            };

            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            if (roles.Select(r => r.ToLower()).Contains("admin"))
                claims.Add(new Claim("role", "admin"));
            else
                claims.Add(new Claim("role", "user"));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}