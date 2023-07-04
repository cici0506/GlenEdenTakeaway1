using System.ComponentModel.DataAnnotations;

namespace GlenEdenTakeaway.Models
{
    public class Order
    {
        [Display(Name = "Order")]
        public int OrderId { get; set; }
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public string Quantity { get; set; }
        [Required(ErrorMessage = "An Item Name is required")]
        [Display(Name = "Item Name")]
        [StringLength(160)]
        public string ItemName { get; set; }
        [Required]
        [Range(1.00, 300.00, ErrorMessage = "Price must be between 1.00 and 300.00")]
        public decimal Price {get; set;}
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        public virtual ICollection<Customer> Customer { get; set; } = new List<Customer>();

        public virtual ICollection<Employee> Employee { get; set; } = new List<Employee>();
        public virtual ICollection<Payment> Payment { get; set; } = new List<Payment>();
    }
}
