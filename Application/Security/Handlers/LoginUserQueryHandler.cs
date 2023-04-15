using Application.Security.DTOs;
using Application.Security.Interfaces;
using Application.Security.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Security.Handlers
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserResult>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IJwtTokenService jwtTokenService;

        public LoginUserQueryHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtTokenService jwtTokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtTokenService = jwtTokenService;
        }

        public async Task<LoginUserResult> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if (user == null) return LoginUserResult.Failed;

            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded) return LoginUserResult.Failed;

            return LoginUserResult.Success(user.Id, user.UserName, jwtTokenService.GenerateToken(user));
        }
    }
}
