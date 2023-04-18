using System.ComponentModel.DataAnnotations;

namespace Demo.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public Customer Customer { get; set; }
    }
}
