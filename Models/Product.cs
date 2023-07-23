using System.ComponentModel.DataAnnotations;

namespace Fast_Food_online.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get;set; }
        [Required]
        public string ImageUrl { get; set; }
        public virtual Category category { get; set; }
    }
}
