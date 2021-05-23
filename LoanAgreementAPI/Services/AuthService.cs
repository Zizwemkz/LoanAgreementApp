using LoanAgreementAPI.Interface;
using LoanAgreementAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoanAgreementAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        public AuthService(UserManager<ApplicationUser> userManager,ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _dbContext = applicationDbContext;
        }

        public async Task<Response> RegisterAsync(RegisterModel registerModel)
        {
            var userExist = await _userManager.FindByNameAsync(registerModel.UserName);
            if (userExist != null)
                return new Response { StatusCode = 500, Message = "User already exist" };

            ApplicationUser user = new ApplicationUser()
            {
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.UserName,
                PhoneNumber = registerModel.phone,
                FirstName =  registerModel.FirstName,
                LastName = registerModel.LastName
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
            {
                return new Response { StatusCode = 500, Message = "User creation failed" };
            }

            return new Response { StatusCode = 200, Message = "User created successful" };
        }



        public async Task<RegisterModel> GetApplicationuser(RegisterModel registerModel)
        {
            var result = await _userManager.FindByEmailAsync(registerModel.Email);

            var Userobj = new RegisterModel
            {
                FirstName = result.FirstName,
                LastName =  result.LastName
            };

            return Userobj;
        }



        public async Task<Response> LogInAsync(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                return new Response
                {
                    Message = "Successful logged in",
                    StatusCode = 200
                };           
            }

            return new Response
            {
                Message = "Invalid username or password",
                StatusCode = 500
            };

        }

        public async Task<int> UpdateuserProfile(ApplicationUser applicationuser)
        {
            var result = await _userManager.FindByEmailAsync(applicationuser.Email);

            result.FirstName = applicationuser.FirstName;
            result.LastName = applicationuser.LastName;

            _dbContext.Update(result);
            return await _dbContext.SaveChangesAsync();
        }

    
    }
}
