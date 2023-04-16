using Application.Security.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        private readonly RestaurantDbContext dbContext;

        public RestaurantRepository(RestaurantDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
