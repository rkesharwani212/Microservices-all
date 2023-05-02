using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityService.Models;
using IndentityServer.Models;
using IndentityServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndentityServer.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUp signUp)
        {
            var result = await _accountService.CreateUser(signUp);

            if(result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] SignIn signIn)
        {
            //if(ModelState.IsValid)
            //{
            //    var result = await _accountService.LoginUser(signIn);
            //    if(result.Succeeded)
            //    {
            //        return Ok(result);
            //    }
            //}

            //return Unauthorized();
            var result = await _accountService.LoginUser(signIn);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.SignOut();
            return Ok();
        }
    }
}