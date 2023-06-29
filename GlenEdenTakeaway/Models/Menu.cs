namespace GlenEdenTakeaway.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string MenuItems { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Customer> Customer { get; set; } = new List<Customer>();
    }
}
