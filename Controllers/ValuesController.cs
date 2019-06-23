using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhoneBook.Models;
using System.Data;
using System.Web.Http.Cors; // пространство имен CORS

namespace PhoneBook.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        BookContext db = new BookContext();

        public IEnumerable<User> GetUsers()
        {
            return db.Users;
        }

        public User GetUser(int id)
        {
            User user = db.Users.Find(id);
            return user;
        }

        [HttpPost]
        public void CreateUser([FromBody]User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditUser(int id, [FromBody]User user)
        {
            if (id == user.id)
            {
                db.Entry(user).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}