﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAngular.Models
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
        public string Category { get; set; }
        
        [Required]
        public decimal Price { get; set; }
    }
}