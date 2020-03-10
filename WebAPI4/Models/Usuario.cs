using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI4.Models
{
    public class Usuario
    {
        [Key]public Int32 id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}