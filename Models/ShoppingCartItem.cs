using System.ComponentModel.DataAnnotations;

namespace Fast_Food_online.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Product Item {  get; set; }
        [Required]
        public int Amount { get;set; }
        public string ShoppingCartId { get; set; }

    }


       

    
}
