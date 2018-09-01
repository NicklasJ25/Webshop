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

        // GET api/values
        public List<Product> Get()
        {
            List<Product> products = database.Product.ToList();
            return products;
        }

        // GET api/values/5
        public Product Get(int id)
        {
            Product product = database.Product.Find(id);
            return product;
        }

        // POST api/values
        public void Post([FromBody]Product product)
        {
            database.Product.Add(product);
            database.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Product product = database.Product.Find(id);
            database.Product.Remove(product);
            database.SaveChanges();
        }
    }
}
