using System.ComponentModel.DataAnnotations;

namespace GlenEdenTakeaway.Models
{
    public class Customer
    {
        
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Please enter first name"),StringLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name"), StringLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter a email address")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
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
