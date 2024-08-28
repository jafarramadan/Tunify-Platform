using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System.Security.Claims;
using TunifyPlatform.Models;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Repositories.Services
{

    public class IdentityAccountServices : IAccountt
    {
        private readonly UserManager<ApplicationUser> _accountManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //inject JWT 
        private JwtTokenService _jwtTokenService;
        public IdentityAccountServices(UserManager<ApplicationUser> Manager, SignInManager<ApplicationUser> signInManager , JwtTokenService jwtTokenService)
        {
            _accountManager = Manager;
            _signInManager = signInManager;
            _jwtTokenService= jwtTokenService;
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
            var x = registerdAccountDto.Roles;
            if (result.Succeeded)
            {
                await _accountManager.AddToRolesAsync(account, registerdAccountDto.Roles);
                return new AccountDto()
                {
                    Id=account.Id,
                    UserName=account.UserName,
                    Token = await _jwtTokenService.GenerateToken(account, System.TimeSpan.FromMinutes(7)),
                    Roles =await _accountManager.GetRolesAsync(account)
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
                    UserName = account.UserName,
                    Token = await _jwtTokenService.GenerateToken(account, System.TimeSpan.FromMinutes(7)),
                    Roles = await _accountManager.GetRolesAsync(account)
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
        //deleteAccount

        public async Task<AccountDto> deleteAccount(string username)
        {
            var account = await _accountManager.FindByNameAsync(username);
            if (account == null)
            {
                throw new Exception("Account not found.");
            }

            await _accountManager.DeleteAsync(account);

            var result = new AccountDto()
            {
                Id = account.Id,
                UserName = account.UserName
            };

            return result;

        }
        public async Task<AccountDto> GetTokens(ClaimsPrincipal claimsPrincipal)
        {

            var newToken = await _accountManager.GetUserAsync(claimsPrincipal);

            if (newToken == null)
            {
                throw new InvalidOperationException("Token is not exist");
            }
            return new AccountDto()
            {
                Id = newToken.Id,
                UserName = newToken.UserName,
                Token = await _jwtTokenService.GenerateToken(newToken,System.TimeSpan.FromMinutes(5))
            };
        }
    }
}