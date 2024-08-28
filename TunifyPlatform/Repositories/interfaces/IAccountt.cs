using System.Security.Claims;
using TunifyPlatform.Models.DTO;

namespace TunifyPlatform.Repositories.interfaces
{
    public interface IAccountt
    {
        //Add register 
       public  Task<AccountDto> Register(RegisterdAccountDto registerdAccountDto);
        //Add login
        public Task<AccountDto> AccountAuthentication(string username , string password);
        public Task<AccountDto> LogOut(string username);
        public Task<AccountDto> GetTokens(ClaimsPrincipal claimsPrincipal);
        public Task<AccountDto> deleteAccount(string username);
        

    }
}
