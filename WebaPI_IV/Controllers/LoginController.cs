
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.Http;
using WebaPI_IV.DataBase;
using WebaPI_IV.Models.ModelLogin;

namespace WebaPI_IV.Controllers
{
    public class LoginController : ApiController
    {
        public DataAccess data = new DataAccess();
      
        [HttpPost]
        public void NewPassword([FromBody]NewPassword user) {
            //check if user exist
            //check if post return a data password
            if (String.IsNullOrEmpty(user.Password))
            {//generate new random password 
                var random = Path.GetRandomFileName();
                user.Password = random.Replace(".", "").Substring(0, 5);
                //set on bank 
                
                //send to email

            }
                
                //else
                //just update with newPassword

                throw new NotImplementedException();
        }
        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }

        public bool SendEmail(string email,string name,string senha)
        {
            MailAddress addressFrom = new MailAddress("MobileStorePI@outlook.com", "Mobile Store");
            MailAddress addressTo = new MailAddress(email, name);
            MailMessage message = new MailMessage(addressFrom, addressTo);

            message.Subject = "Mobile Store, New Password Request";
            string htmlString = $@"<html>
                      <body>
                      <p>Ola Sr(a). {name},</p>
                      <p>Recebemos sua solicitação de nova senha.</p></br>
                      <p>Sua nova senha é : {senha}</p>
                      <p>Agradecemos a preferência e boas compras!<br>-Jack</br></p>
                      </body>
                      </html>
                     ";
            message.Body = htmlString;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.outlook.com";
            client.Port = 587;
            client.Credentials = new NetworkCredential("MobileStorePI@outlook.com", "mobileprojetopi");
            client.UseDefaultCredentials = true;
            client.EnableSsl=true;
            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception)
            {

                return false;
            } 

        }
    }
}
