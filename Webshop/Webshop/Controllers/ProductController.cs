using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Managers;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Products
        public ActionResult Products(string type)
        {
            ViewBag.Title = type;

            List<Product> products = APIManager.Get<List<Product>>("Product");
            products = products.Where(x => x.Type == type).ToList();
            return View(products);
        }

        // GET: Product
        public ActionResult Product(int productId)
        {
            Product product = APIManager.Get<Product>("Product/" + productId);
            ViewBag.Title = product.Title;

            return View(product);
        }
    }
}