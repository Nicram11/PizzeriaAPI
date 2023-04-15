using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string OrderStatus { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        [ForeignKey("Employee")]
        public int DelivererId { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; } 
        public virtual Employee Employee{ get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
