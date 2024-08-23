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

    }
}
