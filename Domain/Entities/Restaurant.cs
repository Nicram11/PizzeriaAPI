namespace Domain.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        public virtual ICollection<Pizza> Pizzas { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<DeliveryProvider> RestaurantDeliveryProviders { get; set; }
    }
}
