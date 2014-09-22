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

        public Order Post([FromBody]Order order)
        {
            db.Orders.Add(order);
            db.ChangeTracker.Entries<Product>().ToList().ForEach(p => p.State = EntityState.Unchanged);
            db.SaveChanges();
            order.Products = null;
            
            return order;
        }
    }
}
