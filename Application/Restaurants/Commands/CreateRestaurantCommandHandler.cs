using Application.Restaurants.DTOs;
using Application.Security.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Restaurants.Commands
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, CreateRestaurantResult>
    {
        private readonly IRestaurantRepository restaurantRepository;

        public CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public async Task<CreateRestaurantResult> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = new Restaurant { Name = request.Name, Address = request.Address, PhoneNumber = request.PhoneNumber };
            var result = await restaurantRepository.AddAsync(restaurant, cancellationToken);
            if (result == null)
                return CreateRestaurantResult.Failed;

            return CreateRestaurantResult.Success(result.Id);
        }
    }
}
