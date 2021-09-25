using Core.Application.Contracts.Data;
using Core.Application.Contracts.Services;
using Core.Application.DTO;
using Core.Application.Options;
using Core.Domain.Model;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IBRMContext _brmContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IOrganizationService _organizationService;

        //public JwtSettings _JwtSettings { get; }
        public IdentityService(UserManager<ApplicationUser> userManager,
                               JwtSettings jwtSettings,
                               IOrganizationService organizationService,
                               IBRMContext brmContext
            )
        {
            this._brmContext = brmContext;
            this._userManager = userManager;
            this._jwtSettings = jwtSettings;
            this._organizationService = organizationService;
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
            var user = new ApplicationUser { UserName = email, Email = email };
            var createdUser = await _userManager.CreateAsync(user, password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult { Sussess = false, Errors = createdUser.Errors.Select(e => e.Description) };
            }

            return GenerateAuthenticationResult(user);
        }
        public async Task<AuthenticationResult> RegisterAsync(string email, string name, string password)
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
            var user = new ApplicationUser { UserName = name, Email = email };
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
                var user = new UserDTO
                {
                    Email = existingUser.Email,
                    NormalizedEmail = existingUser.NormalizedEmail,
                    NormalizedUserName = existingUser.NormalizedUserName,
                    UserName = existingUser.UserName
                };
                return new AuthenticationResult
                {
                    Sussess = false,
                    Errors = new[] { "User or Pasword incorrect." },
                    User = user
                };
            }
            return GenerateAuthenticationResult(existingUser);
        }
        private AuthenticationResult GenerateAuthenticationResult(ApplicationUser user)
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

            var userResponse = new UserDTO
            {
                Email = user.Email,
                NormalizedEmail = user.NormalizedEmail,
                NormalizedUserName = user.NormalizedUserName,
                UserName = user.UserName
            };
            var org = new CompanyDTO
            {
                Id = Guid.NewGuid(),
                Enabled = false
            };
            _organizationService.Create(org);
            
            return new AuthenticationResult
            {
                Sussess = true,
                Token = tokenHandeler.WriteToken(token),
                User = userResponse
            };
        }

    }
}
