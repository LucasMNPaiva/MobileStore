using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebaPI_IV.DataBase;

namespace WebaPI_IV.Models.ModelClient
{
    public class ClientRepository : IClient
    {

        static readonly DataAccess data = new DataAccess();
        public Client Add(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("produto");
            }
            data.NewClient(client);
            return client;

        }

        public Client Get(int id)
        {
            return data.GetClients().Find(c => c.Id == id);
        }

        public IEnumerable<Client> GetAll()
        {
            return data.GetClients();
        }

        public void Remove(int id)
        {
            data.DeleteClient(id);
        }

        public bool Update(Client client)
        {
            return data.UpdateClient(client);
        }
    }
}