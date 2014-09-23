using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using ProAngular.Infrastructure;
using ProAngular.Models;

namespace ProAngular.Controllers
{
    public class OrdersController : ApiController
    {
        private ProductsDb db = new ProductsDb();

        public OrderDto Post([FromBody]OrderDto order)
        {
            var entity = order.ToOrder();
            db.Orders.Add(entity);
            db.ChangeTracker.Entries<Product>().ToList().ForEach(p => p.State = EntityState.Unchanged);
            db.SaveChanges();
            
            order.Id = entity.Id;
            return order;
        }

        [Authorize(Users = "admin")]
        public IEnumerable<OrderDto> Get()
        {
            var orders = db.Orders.Include("Products.Product").ToList();
            var orderDtos = orders.Select(OrderDto.FromOrder);
            return orderDtos;
        }
    }

    public class OrderDto
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
        public ICollection<OrderDetailDto> Products { get; set; }

        public Order ToOrder()
        {
            return new Order
            {
                Id = Id,
                City = City,
                Country = Country,
                Giftwrap = Giftwrap,
                Name = Name,
                State = State,
                Street = Street,
                Zip = Zip,
                Products = Products.Select(p => new OrderProduct
                {
                    Count = p.Count, 
                    Price = p.Price,
                    Product = new Product() { Id = p.Id}
                }).ToList()
            };
        }

        public static OrderDto FromOrder(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                City = order.City,
                Country = order.Country,
                Giftwrap = order.Giftwrap,
                Name = order.Name,
                State = order.State,
                Street = order.Street,
                Zip = order.Zip,
                Products = order.Products.Select(p => new OrderDetailDto()
                {
                    Count = p.Count,
                    Price = p.Price,
                    Id = p.Product.Id,
                    Name = p.Product.Name
                }).ToList()
            };
        }
    }

    public class OrderDetailDto
    {
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
