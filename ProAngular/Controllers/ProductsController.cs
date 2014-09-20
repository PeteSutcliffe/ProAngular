using System.Collections.Generic;
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
    }
}
