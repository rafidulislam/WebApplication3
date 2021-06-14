using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class AccountRepository : IAccountRepository
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(User user)
        {
            var User = new ApplicationUser()
            {
                FirstName=user.FirstName,
                LastName=user.LastName,
                Email= user.Email,
                UserName= user.Email,
            };
            var result = await _userManager.CreateAsync(User, user.Password);
            return result;
        }
    }
}
