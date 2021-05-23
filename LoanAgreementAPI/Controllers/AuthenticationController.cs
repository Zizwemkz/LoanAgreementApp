using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanAgreementAPI.Interface;
using LoanAgreementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LoanAgreementAPI.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _IAuthService;
        // GET: api/Category

        public AuthenticationController(IAuthService IAuthService)
        {
            _IAuthService = IAuthService;
        }


        [HttpPost]
        public async Task<Response> Register([FromBody] RegisterModel registerModel)
        {
            var result = await _IAuthService.RegisterAsync(registerModel);

            return result;
        }


        [HttpPost]
        public async Task<Response> LogIn([FromBody] LoginModel loginModel)
        {
            var result = await _IAuthService.LogInAsync(loginModel);

            return result;
        }

        [HttpGet]
        public async Task<RegisterModel> GetUser([FromBody] RegisterModel loginModel)
        {
            var result = await _IAuthService.GetApplicationuser(loginModel);

            return result;
        }


    }
}
