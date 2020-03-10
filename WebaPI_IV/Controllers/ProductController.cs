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
    public class ProductController : ApiController
    {
        static readonly IProductRepository productRepository = new ProductRepository();
        // GET: api/Product
        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        // GET: api/Product/5
        public Product GetProduct(int id)
        {
            Product produto = productRepository.Get(id);
            if (produto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return produto;
        }

        // POST: api/Product
            [HttpPost]
            public string[] CreateProduct()
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            //HttpContext.Current.Request.Params["Name"];
            //HttpContext.Current.Request.Params["Price"];

            var path = new string[files.Count];
            for(var i = 0; i < files.Count; i++)
            {
                //save new product on SQL database
                HttpPostedFile file = files[i];
                string roothPath = "~/Upload/" + Guid.NewGuid()+".png";
                path[i] = roothPath.Substring(1);
                file.SaveAs(HttpContext.Current.Server.MapPath(roothPath));
               
            }
            return path;
        }

        // PUT: api/Product/5
        public HttpStatusCode Put(int id, [FromBody]Product produto)
        {
            produto.Id = id;
            if (!productRepository.Update(produto))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return HttpStatusCode.OK;
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            Product produto = productRepository.Get(id);
            if (produto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            productRepository.Remove(id);
        }

        public IEnumerable<Product> GetUsersByCategory(string categoria)
        {
            return productRepository.GetAll().Where(u => string.Equals(u.Category, categoria, StringComparison.OrdinalIgnoreCase));
        }
    }
}
