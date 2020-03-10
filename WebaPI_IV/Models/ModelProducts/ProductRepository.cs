using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebaPI_IV.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();
        private int _nextId = 1;
        public Product Add(Product produto)
        {
            //insert product on db
            if (produto == null)
            {
                throw new ArgumentNullException("produto");
            }
            produto.Id = _nextId++;
            products.Add(produto);
            return produto;
            throw new NotImplementedException();
        }

        public ProductRepository()
        {
            //get all products in db to list of products
        }
        
        public Product Get(int id)
        {
           return products.Find(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public void Remove(int id)
        {
            // delete all products with this ID
            throw new NotImplementedException();
        }

        public bool Update(Product produto)
        {
            throw new NotImplementedException();
        }
    }
}