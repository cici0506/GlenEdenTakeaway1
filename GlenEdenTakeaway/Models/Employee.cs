using System.ComponentModel.DataAnnotations;

namespace GlenEdenTakeaway.Models
{
    public class Employee
    {
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }
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
        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
