using AgainBefore.Models;
using Microsoft.AspNetCore.Identity;

namespace AgainBefore.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInUserModel signInModel);
        Task SignOutAsync();
       
  
       


    }
}
