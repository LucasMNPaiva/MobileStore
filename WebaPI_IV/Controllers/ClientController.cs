using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebaPI_IV.DataBase;
using WebaPI_IV.Models.ModelClient;

namespace WebaPI_IV.Controllers
{
    public class ClientController : ApiController
    {

        static readonly DataAccess data = new DataAccess();
        static readonly ClientRepository clientRepository = new ClientRepository();
        // GET: api/Client
        public IEnumerable<Client> GetAll()
        {
            return clientRepository.GetAll();
        }

        // GET: api/Client/5
        public Client GetClient(int id)
        {
            var client = clientRepository.Get(id);
            if (client == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return client;
        }

        // POST: api/Client
        public HttpResponseMessage PostClient([FromBody]Client client)
        {
            if(client ==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

          client=  clientRepository.Add(client);
            var response = Request.CreateResponse<Client>(HttpStatusCode.Created, client);
            var uri = Url.Link("DefaultApi", new { id = client.Id });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        // PUT: api/Client/5
        public void Put(int id, [FromBody]Client client)
        {
            client.Id = id;
            if(clientRepository.Update(client))
                throw new HttpResponseException(HttpStatusCode.NotFound);

        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
            var client = clientRepository.Get(id);
            if(client==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            clientRepository.Remove(id);
        }

       
    }
}
