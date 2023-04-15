using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalPrice { get; set; }

        public string UserId { get; set; }
        public int RestaurantId { get; set; }
        public int DeliveryProviderId { get; set; }


        public virtual Restaurant Restaurant { get; set; } 
        public virtual DeliveryProvider DeliveryProvider { get; set; } 
        public virtual ApplicationUser User { get; set; }
       
        public virtual ICollection<OrderPizza> OrderPizzas{ get; set; }
    }
}
