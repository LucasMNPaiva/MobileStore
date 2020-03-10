using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI4.Models
{
    public class User : DbContext
    {
        public User() : base ("name=MeuContext")
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}