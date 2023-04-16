using Application.Security.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Restaurants.Queries
{
    public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, Restaurant >
    {
        private readonly IRestaurantRepository restaurantRepository;

        public GetRestaurantByIdQueryHandler(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public async Task<Restaurant> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            return await restaurantRepository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
