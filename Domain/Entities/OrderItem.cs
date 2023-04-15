using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
  
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public int DishID { get; set; }
        public virtual Dish Dish { get; set; }

    
    }
}
