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
        public virtual ICollection<Order> Orders { get; set; }
    }
}
