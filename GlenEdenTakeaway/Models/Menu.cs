using System.ComponentModel.DataAnnotations;

namespace GlenEdenTakeaway.Models
{
    public class Menu
    {
        [Display(Name = "Menu")]
        public int MenuId { get; set; }
        [Required]
        [Display(Name = "Menu Items")]
        public string MenuItems { get; set; }
        [Required]
        [Range(1.00, 30.00, ErrorMessage = "Price must be between 1.00 and 30.00")]
        public decimal Price { get; set; }

        public virtual ICollection<Customer> Customer { get; set; } = new List<Customer>();
    }
}
