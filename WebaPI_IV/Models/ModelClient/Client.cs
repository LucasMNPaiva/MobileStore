using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebaPI_IV.Models.ModelClient
{
    public class Client
    {
        public Int32 Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}