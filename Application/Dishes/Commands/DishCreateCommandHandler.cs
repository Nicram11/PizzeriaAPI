using Application.Dishes.DTOs;
using Application.DTOs;
using Application.Security.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dishes.Commands
{
    public class DishCreateCommandHandler : IRequestHandler<DishCreateCommand, DishCreateCommandResult>
    {
        private readonly IGenericRepository<Domain.Entities.Dish> dishRepository;

        public DishCreateCommandHandler(IGenericRepository<Dish> dishRepository)
        {
            this.dishRepository = dishRepository;
        }

        public async Task<DishCreateCommandResult> Handle(DishCreateCommand request, CancellationToken cancellationToken)
        {
            var dish = new Dish
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Category = request.Category,
                RestaurantID = request.RestaurantID
            };

            dish = await dishRepository.AddAsync(dish, cancellationToken);
            if (dish.DishID ==0)
                return DishCreateCommandResult.Failed;

            return DishCreateCommandResult.Success(dish.DishID);
        }
    }
}
