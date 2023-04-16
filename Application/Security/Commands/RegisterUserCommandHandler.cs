using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Security.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email
            };
            return await userManager.CreateAsync(user, request.Password);
        }
    }
}
