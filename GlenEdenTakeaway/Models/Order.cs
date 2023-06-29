using System.ComponentModel.DataAnnotations;

namespace GlenEdenTakeaway.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public string Quantity { get; set; }
        public string ItemName { get; set; }
        public decimal Price {get; set;}
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public virtual ICollection<Customer> Customer { get; set; } = new List<Customer>();

        public virtual ICollection<Employee> Employee { get; set; } = new List<Employee>();
        public virtual ICollection<Payment> Payment { get; set; } = new List<Payment>();
    }
}
