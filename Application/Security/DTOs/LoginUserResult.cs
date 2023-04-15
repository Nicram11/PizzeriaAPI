using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Security.DTOs
{
    public class LoginUserResult
    {
        public string UserId { get; private set; }
        public string UserName { get; private set; }
        public string Token { get; private set; }
        public bool Successed { get; private set; }


        public static LoginUserResult Success(string userId, string userName, string token)
        {
            return new LoginUserResult()
            {
                UserId = userId,
                UserName = userName,
                Token = token,
                Successed = true
            };
        }
        
        public static LoginUserResult Failed => new LoginUserResult() { Successed = false };
    }
}
