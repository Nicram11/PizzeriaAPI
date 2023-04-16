using Domain.Entities;
using MediatR;

namespace Application.Security.Queries
{
    public class GetCurrentUserQuery: IRequest<ApplicationUser>
    {
        public string UserName { get; set; }
    }
}
