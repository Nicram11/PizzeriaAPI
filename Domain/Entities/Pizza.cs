using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Domain.Entities
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; } 
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        
        public virtual ICollection<OrderPizza> OrderPizzas { get; set; }
    }
}
