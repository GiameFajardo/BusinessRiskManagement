using Core.Application.Contracts.Data;
using Core.Application.Contracts.Services;
using Core.Application.Options;
using Core.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IBRMContext brmContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        //public JwtSettings _JwtSettings { get; }
        public IdentityService(UserManager<IdentityUser> userManager,
                               JwtSettings jwtSettings
            )
        {
            this._userManager = userManager;
            this._jwtSettings = jwtSettings;
        }


        public async Task<AuthenticationResult> RegisterAsync(string email, string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Sussess = false,
                    Errors = new[] { "User with email address already exists." }
                };
            }
            var user = new IdentityUser { UserName = email, Email = email };
            var createdUser = await _userManager.CreateAsync(user, password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult { Sussess = false, Errors = createdUser.Errors.Select(e => e.Description) };
            }
            return GenerateAuthenticationResult(user);
        }

        public async Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser == null)
            {
                return new AuthenticationResult
                {
                    Sussess = false,
                    Errors = new[] { "User with email address doesn't exists." }
                };
            }
            var userHasValidPass = await _userManager.CheckPasswordAsync(existingUser, password);
            if (!userHasValidPass)
            {
                return new AuthenticationResult
                {
                    Sussess = false,
                    Errors = new[] { "User or Pasword incorrect." }
                };
            }
            return GenerateAuthenticationResult(existingUser);
        }
        private AuthenticationResult GenerateAuthenticationResult(IdentityUser user)
        {
            var tokenHandeler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("id", user.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandeler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Sussess = true,
                Token = tokenHandeler.WriteToken(token)
            };
        }

    }
}
