using Application.Security.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Security.Queries
{
    public class LoginUserQuery : IRequest<LoginUserResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
