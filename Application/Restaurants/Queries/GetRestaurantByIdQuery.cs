using Application.Security.DTOs;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Restaurants.Queries
{
    public class GetRestaurantByIdQuery : IRequest<Restaurant>
    {
        public int Id { get; set; }
    }
}
