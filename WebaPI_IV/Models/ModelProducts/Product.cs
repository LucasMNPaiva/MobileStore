using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebaPI_IV.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        
        public string PathImage { get; set; }
    }
}