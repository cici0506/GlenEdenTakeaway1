namespace GlenEdenTakeaway.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int CustomerId { get; set; }

        public int OrderItemId { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal TotalAmount { get; set; }

        public int PaymentTypeId { get; set; }

        public virtual ICollection<Customer> Customer { get; set; } = new List<Customer>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
