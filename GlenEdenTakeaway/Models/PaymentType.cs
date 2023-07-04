using System.ComponentModel.DataAnnotations;

namespace GlenEdenTakeaway.Models
{
    public class PaymentType
    {
        [Display(Name = "Payment Type")]
        public int PaymentTypeId { get; set; }
        [Required]
        [Display(Name = "Payment Types")]
        [StringLength(160)]
        public string PaymentType1 { get; set; }
    }
}
