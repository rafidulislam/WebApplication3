using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using WebApplication3.Models;
using Xunit;

namespace WebApplication3.Controllers
{
    public class AccountControllar : Controller
    {
        public readonly IAccountRepository _accountRepository;

        public AccountControllar(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        [Route("Signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> SignupAsync(User user)
        {
            if(ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(user);
                if (!result.Succeeded)
                {
                    foreach (var errormassage in result.Errors) 
                    {
                        ModelState.AddModelError("", errormassage.Description);
                    }
                    return View(user);
                }
                ModelState.Clear();
            }
            return View();
        }
    }
}
