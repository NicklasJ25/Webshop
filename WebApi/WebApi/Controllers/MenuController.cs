using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class MenuController : ApiController
    {
        WebshopEntities database = new WebshopEntities();

        // GET api/Menu
        public List<Menu> Get()
        {
            List<Menu> menus = database.Menu.ToList();
            return menus;
        }

        // GET api/Menu/5
        public Menu Get(int id)
        {
            Menu menus = database.Menu.Find(id);
            return menus;
        }

        // POST api/Menu
        public void Post([FromBody]Menu menu)
        {
            database.Menu.Add(menu);
            database.SaveChanges();
        }

        // PUT api/Menu/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Menu/5
        public void Delete(int id)
        {
            Menu menu = database.Menu.Find(id);
            database.Menu.Remove(menu);
            database.SaveChanges();
        }
    }
}
