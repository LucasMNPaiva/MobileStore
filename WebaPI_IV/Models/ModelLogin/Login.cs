using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebaPI_IV.Models.ModelLogin
{
    public class Login
    {
    }
    public class NewPassword
    {
        public string Email { get; set; }
        public string Login { get; set; }
        
        public string Password { get; set; }
    }
}