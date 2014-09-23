using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAngular.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public bool Giftwrap { get; set; }

        [Required]
        public ICollection<OrderProduct> Products { get; set; }
    }

    public class OrderProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}