﻿using System.ComponentModel.DataAnnotations;

namespace Fast_Food_online.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<Category> Categories { get; set; }=new HashSet<Category>();
    }
}
