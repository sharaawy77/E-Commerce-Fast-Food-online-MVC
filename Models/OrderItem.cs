using System.ComponentModel.DataAnnotations;

namespace Fast_Food_online.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int productId { set; get; }
        public virtual Product Item { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public virtual Order order { get; set; }

    }
}
