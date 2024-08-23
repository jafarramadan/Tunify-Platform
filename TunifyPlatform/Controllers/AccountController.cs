using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountt _accountServices;
        public AccountController(IAccountt context)
        {
            _accountServices = context;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AccountDto>> Register(RegisterdAccountDto registerdAccount)
        {
            var account= await _accountServices.Register(registerdAccount);
            return Ok(account);
        }

        //login 

        [HttpPost("Login")]
        public async Task<ActionResult<AccountDto>> Login(LoginDto loginDto)
        {
            var account = await _accountServices.AccountAuthentication(loginDto.UserName, loginDto.Password);
            if (account == null)
            {
                return Unauthorized();
            }
            return account;
        }
        [HttpPost("Logout")]
        
        public async Task<ActionResult<AccountDto>> LogOut(string username)
        {
          var account =  await _accountServices.LogOut(username);
            return account;
        }
    }
}
