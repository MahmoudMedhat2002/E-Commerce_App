namespace E_Commerce_App.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public int UserId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
