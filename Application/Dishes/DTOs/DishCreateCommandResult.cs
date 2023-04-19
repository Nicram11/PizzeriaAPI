using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dishes.DTOs
{
    public class DishCreateCommandResult : CommandResult
    {
        public int Id { get; set; }
        public static DishCreateCommandResult Success(int id) => new DishCreateCommandResult() { Id = id, Successed = true };
        public static DishCreateCommandResult Failed => new DishCreateCommandResult { Successed = false };

    }
}
