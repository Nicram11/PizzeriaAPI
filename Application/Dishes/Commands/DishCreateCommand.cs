using Application.Dishes.DTOs;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace Application.Dishes.Commands
{
    public class DishCreateCommand : IRequest<DishCreateCommandResult>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Category { get; set; }
        [Required]
        public int RestaurantID { get; set; }
    }
}
