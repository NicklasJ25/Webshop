using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductController : ApiController
    {
        WebshopEntities database = new WebshopEntities();

        // GET api/Product
        public List<Product> Get()
        {
            List<Product> products = database.Product.ToList();
            return products;
        }

        // GET api/Product/5
        public Product Get(int id)
        {
            Product product = database.Product.Find(id);
            return product;
        }

        // POST api/Product
        public void Post([FromBody]Product product)
        {
            database.Product.Add(product);
            database.SaveChanges();
        }

        // PUT api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Product/5
        public void Delete(int id)
        {
            Product product = database.Product.Find(id);
            database.Product.Remove(product);
            database.SaveChanges();
        }
    }
}
