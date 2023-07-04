using System.ComponentModel.DataAnnotations;

namespace GlenEdenTakeaway.Models
{
    public class Customer
    {
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "The name entered is too long.")]
        [RegularExpression(@"^[A-Za-z\']*$", ErrorMessage = "Only letters can be used")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "The name entered is too long.")]
        [RegularExpression(@"^[A-Za-z\']*$", ErrorMessage = "Only letters can be used")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter a email address")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        [Display(Name = "Street Address")]
        [StringLength(128, MinimumLength = 3)]
        public string Street { get; set; }
        [StringLength(255)]
        public string City { get; set; }
        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<Menu> Menu { get; set; } = new List<Menu>();



    }
}
