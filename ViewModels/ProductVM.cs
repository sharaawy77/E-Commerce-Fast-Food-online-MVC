using Fast_Food_online.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Fast_Food_online.ViewModels
{
    public class ProductVM
    {
        public List<Category> Categories { get; set; }
        public Category category { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        
        public IFormFile Image { get; set; }
        public int CatId { get; set; }
        public string ImageURl { get; set; }

    }
}
