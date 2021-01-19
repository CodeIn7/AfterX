using AfterX;
using AfterX_backend.Domain;
using AfterX_backend.Options;
using AfterX_backend.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AfterX_backend.Services.ServiceImplementations
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly DataContext _dataContext;
        private readonly JwtSettings _jwtSettings;
        public IdentityService(UserManager<User> userManager, JwtSettings jwtSetting, DataContext dataContext)
        {
            _userManager = userManager;
            _jwtSettings = jwtSetting;
            _dataContext = dataContext;
        }

        public async Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            var user = await _dataContext.Users
                .FirstOrDefaultAsync(m => m.Email == email);//await _userManager.FindByEmailAsync(email);
            var userattribues = await _dataContext.Userattribues
                .FirstOrDefaultAsync(m => m.Userid == user.Id);//await _userManager.FindByEmailAsync(email);
            user.Userattribue = userattribues;
            if (user == null)
                return new AuthenticationResult
                {
                    Errors = new[] { "User does not exist" }
                };

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!userHasValidPassword)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Username/password don't match" }
                };
            }

            return GenerateAuthenticationResultForUser(user);
        }

        public async Task<AuthenticationResult> RegisterAsync(User newUser,string password, string roleName)
        {
            var existingUser = await _userManager.FindByEmailAsync(newUser.Email);

            if (existingUser != null) return new AuthenticationResult
            {
                Errors = new[] { "User with this email already exists" }
            };


            var createdUser = await _userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }
            var role = await _dataContext.Roles
                .FirstOrDefaultAsync(m => m.Name.ToUpper() == roleName.ToUpper());
            await _userManager.AddToRoleAsync(newUser, role.NormalizedName);

            return GenerateAuthenticationResultForUser(newUser);

        }



        private AuthenticationResult GenerateAuthenticationResultForUser(User newUser)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id.ToString()),
                    new Claim("Firstname", newUser.Userattribue.Firstname),
                    new Claim("Lastname", newUser.Userattribue.Lastname)

                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
