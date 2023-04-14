namespace Domain.Entities
{
    public class DeliveryProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
