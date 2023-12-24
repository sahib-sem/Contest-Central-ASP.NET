using Application.Contracts;
using Application.Dto.Authentication.Dto;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Persistence.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Persistence.Repositories
{
    public class AuthService : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        //public async Task<AuthResponse> Login(ApplicationUser request)
        //{
        //    var user = await _userManager.FindByEmailAsync(request.Email);

        //    if (user == null)
        //    {
        //        throw new Exception($"User with {request.Email} not found.");
        //    }

        //    var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

        //    if (!result.Succeeded)
        //    {
        //        throw new Exception($"Credentials for '{request.Email} aren't valid'.");
        //    }

        //    JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

        //    AuthResponse response = new AuthResponse
        //    {
        //        Id = user.Id,
        //        Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
        //        Email = user.Email,
        //        UserName = user.UserName
        //    };

        //    return response;
        //}

        public async Task<ApplicationUser> Register(RegisterUserDto request)
        {
            Console.WriteLine("HelloOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            Console.WriteLine(request);
            Console.WriteLine(request.UserName);
            //var existingUser = await _userManager.FindByNameAsync(request.UserName);
            var existingUser = (string)null;

            Console.WriteLine(existingUser);

            if (existingUser != null)
            {
                throw new Exception($"Username '{request.UserName}' already exists.");
            }

            Console.WriteLine("UserDoesnt EXiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiist");

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);
            Console.WriteLine(existingEmail);
            Console.WriteLine("Ho");

            if (existingEmail == null)
            {
                Console.WriteLine("About register userrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr");
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)

                {
                    var roles = _roleManager.Roles.Select(role => role.Name).ToList();
                    foreach (var role in roles)
                    {
                        Console.WriteLine("Roooooooooooooooooooooooooooooooles");
                        Console.WriteLine(role);
                    }
                    await _userManager.AddToRoleAsync(user, "ADMINISTRATOR");
                    return user;
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new Exception($"Email {request.Email} already exists.");
            }
        }

        //private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        //{
        //    var userClaims = await _userManager.GetClaimsAsync(user);
        //    var roles = await _userManager.GetRolesAsync(user);

        //    var roleClaims = new List<Claim>();

        //    for (int i = 0; i < roles.Count; i++)
        //    {
        //        roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
        //    }

        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //        new Claim(CustomClaimTypes.Uid, user.Id)
        //    }
        //    .Union(userClaims)
        //    .Union(roleClaims);

        //    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        //    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        //    var jwtSecurityToken = new JwtSecurityToken(
        //        issuer: _jwtSettings.Issuer,
        //        audience: _jwtSettings.Audience,
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
        //        signingCredentials: signingCredentials);
        //    return jwtSecurityToken;
        //}
    }
}

