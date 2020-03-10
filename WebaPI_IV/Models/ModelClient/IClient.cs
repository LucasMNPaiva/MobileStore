using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebaPI_IV.Models.ModelClient
{
    public interface IClient
    {
        IEnumerable<Client> GetAll();
        Client Get(int id);
        Client Add(Client client);
        void Remove(int id);
        bool Update(Client client);
    }
}
