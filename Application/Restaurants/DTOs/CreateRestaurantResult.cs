using Application.Security.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Restaurants.DTOs
{
    public class CreateRestaurantResult
    {
        public int Id { get; set; }
        public bool Successed { get; private set; }
        public static CreateRestaurantResult Success(int Id) => new CreateRestaurantResult() {  Id = Id, Successed = true};
    

        public static CreateRestaurantResult Failed => new CreateRestaurantResult() { Successed = false };
    }
}
