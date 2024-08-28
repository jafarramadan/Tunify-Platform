﻿namespace TunifyPlatform.Models.DTO
{
    public class AccountDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }    

        public IList<string> Roles { get; set; }
    }
}
