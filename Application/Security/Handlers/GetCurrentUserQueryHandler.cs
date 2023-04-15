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
    public class GetCurrentUserQueryHandler :IRequestHandler<GetCurrentUserQuery, ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetCurrentUserQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            return await _userManager.FindByNameAsync(request.UserName);
        }
    }
}
