using IdentityService.Models;
using IndentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndentityServer.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateUser(SignUp signUp);
        //Task<SignInResult> LoginUser(SignIn signIn);
        Task<string> LoginUser(SignIn signIn);
        Task SignOut();
    }
}
