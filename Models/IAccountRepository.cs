using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(User user);
    }
}