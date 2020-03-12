using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebaPI_IV.DataBase;

namespace WebaPI_IV.Models
{
    public class ProductRepository : IProductRepository
    {
        static readonly DataAccess data = new DataAccess();
        public Product Add(Product produto)
        {
            //insert product on db
            if (produto == null)
            {
                throw new ArgumentNullException("produto");
            }
            data.NewProduct(produto);
            return produto;
        }

        
        public Product Get(int id)
        {
           return data.GetProducts().Find(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return data.GetProducts();
        }

        public void Remove(int id)
        {
            // delete all products with this ID
            data.DeleteProduct(id);
        }

        public bool Update(Product produto)
        {
           return data.UpdateProduct(produto);
        }
    }
}