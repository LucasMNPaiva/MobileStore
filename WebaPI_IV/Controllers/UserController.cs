using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebaPI_IV.Models;

namespace WebaPI_IV.Controllers
{
    public class UserController : ApiController
    {
        static readonly IUser userRepository = new UserRepository();

        public IEnumerable<User> GetAllProducts()
        {
            return userRepository.GetAll();
        }


        public User GetUser(int id)
        {
            User user = userRepository.Get(id);
            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return user;
        }

        public IEnumerable<User> GetUsersByCategory(string categoria)
        {
            return userRepository.GetAll().Where(u => string.Equals(u.Categoria, categoria, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostUser([FromBody] User user)
        {
            user = userRepository.Add(user);
            var response = Request.CreateResponse<User>(HttpStatusCode.Created, user);
            var uri = Url.Link("DefaultApi", new { id = user.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutUser (int id,User user)
        {
            user.Id = id;
            if (!userRepository.Update(user))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteUser(int id)
        {
            User user = userRepository.Get(id);
            if(user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            userRepository.Remove(id);
        }

    }
}
