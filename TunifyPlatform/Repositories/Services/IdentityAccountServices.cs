using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using TunifyPlatform.Models;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Repositories.Services
{

    public class IdentityAccountServices : IAccountt
    {
        private readonly UserManager<ApplicationUser> _accountManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public IdentityAccountServices(UserManager<ApplicationUser> Manager, SignInManager<ApplicationUser> signInManager)
        {
            _accountManager = Manager;
            _signInManager = signInManager;
        }
        
        //register
        public async Task<AccountDto> Register(RegisterdAccountDto registerdAccountDto)
        {
            var account = new ApplicationUser()
            {
                UserName = registerdAccountDto.UserName,
                Email = registerdAccountDto.Email,

            };
            var result =await _accountManager.CreateAsync(account,registerdAccountDto.Password);

            if (result.Succeeded)
            {
                return new AccountDto()
                {
                    Id=account.Id,
                    UserName=account.UserName
                };
            }

            return null;
        }
        //loginn
        public async Task<AccountDto> AccountAuthentication(string username, string password)
        {
           var account = await _accountManager.FindByNameAsync(username);
           bool passValidation =await _accountManager.CheckPasswordAsync(account, password);
            if (passValidation)
            {
                return new AccountDto()
                {
                    Id = account.Id,
                    UserName = account.UserName
                };
            }
            return null;
        }
        //logout
        
        public async Task<AccountDto> LogOut(string username)
        {
            var account = await _accountManager.FindByNameAsync(username);
            if (account == null)
            {
                throw new Exception("Account not found.");
            }
            
            await _signInManager.SignOutAsync();

            var result = new AccountDto()
            {
                Id = account.Id,
                UserName = account.UserName
            };

            return result;

        }
    }
}