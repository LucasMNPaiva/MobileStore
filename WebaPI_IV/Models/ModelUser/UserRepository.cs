using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebaPI_IV.DataBase;

namespace WebaPI_IV.Models
{
    public class UserRepository : IUser
    {

        static readonly DataAccess data = new DataAccess();

        public IEnumerable<User> GetAll()
        {
            return data.GetUsers();
        }
        public User Get(int id)
        {
            return data.GetUsers().Find(u => u.Id == id);
        }
        public User Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            data.NewUser(user);
            return user;
        }

        public void Remove(int id)
        {
            data.DeleteClient(id);
        }
        public bool Update(User user)
        {
           
            return data.UpdateUser(user);
        }


    }
}