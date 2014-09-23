using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using ProAngular.Infrastructure;
using ProAngular.Models;

namespace ProAngular.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ProductsDb _db = new ProductsDb();

        public IEnumerable<Product> Get()
        {
            return _db.Products.ToList();
        }

        public Product Get(int id)
        {
            return _db.Products.Find(id);
        }

        public void Post(int id, [FromBody]Product product)
        {
            _db.Products.Attach(product);
            _db.Entry(product).State = EntityState.Modified;            
            _db.SaveChanges();
        }

        public Product Post([FromBody]Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return product;
        }

        public void Delete(int id)
        {
            _db.Products.Remove(_db.Products.Find(id));
            _db.SaveChanges();
        }
    }
}
