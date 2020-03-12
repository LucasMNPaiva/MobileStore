using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WebaPI_IV.Models;
using WebaPI_IV.Models.ModelClient;
using WebaPI_IV.Models.ModelLogin;

namespace WebaPI_IV.DataBase
{
    public class DataAccess
    {

        public string strcon = "Server=127.0.0.1;Port=3306;Database=MobileStore;Uid=root;Pwd=adminadmin;";

        #region User
        public void ChangePassword(NewPassword data)
        {
            try
            {
                var query = $@"UPDATE CLIENT SET password = {data.Password} WHERE username = {data.Login} AND email= {data.Email}";
                using (MySqlConnection con = new MySqlConnection(strcon))
                {
                    con.Open();
                    var cmd = new MySqlCommand(query, con);

                    cmd.ExecuteNonQuery();


                    con.Close();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }



        public void NewUser(User user)
        {
            try
            {
                var query = $@"INSERT INTO users (name,email,username,password,type) VALUES (@name,@email,@username,@password,@type";
                using (MySqlConnection con = new MySqlConnection(strcon))
                {
                    con.Open();
                    var cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@type", user.Categoria);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                var users = new List<User>();

                var query = $@"SELECT * FROM Users";

                using (MySqlConnection con = new MySqlConnection(strcon))
                {
                    con.Open();
                    var cmd = new MySqlCommand(query, con);
                    var resp = cmd.ExecuteReader();
                    while (resp.Read())
                    {
                        users.Add(new User
                        {
                            Id = resp.GetInt32(0),
                            Name = resp.GetString(1),
                            Email = resp.GetString(2),
                            Username = resp.GetString(3),
                            Password = resp.GetString(4),
                            Categoria = resp.GetString(5)
                        });
                    }
                    con.Close();
                }

                return users;

            }


            catch (Exception)
            {

                throw;
            }

        }
        public bool UpdateUser(User user)
        {
            var query = "UPDATE users SET name=@name,email=@email,username=@username,password=@password,type=@type WHERE idClient = @id";
            try
            {
                using (MySqlConnection con = new MySqlConnection(strcon))
                {
                    con.Open();
                    var cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("name", user.Name);
                    cmd.Parameters.AddWithValue("email", user.Email);
                    cmd.Parameters.AddWithValue("username", user.Username);
                    cmd.Parameters.AddWithValue("password", user.Password);
                    cmd.Parameters.AddWithValue("type", user.Categoria);
                    cmd.Parameters.AddWithValue("id", user.Id);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public void DeleteUser(int id)
        {
            var query = "DELETE * FROM users WHERE idUser = @id";
            using (MySqlConnection con = new MySqlConnection(strcon))
            {
                con.Open();
                var cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("id", id);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                con.Close();
            }


        }
        #endregion

        #region Client
        public List<Client> GetClients()
        {
            try
            {
                var clients = new List<Client>();
                var query = "SELECT * FROM  CLIENT";

                using (MySqlConnection con = new MySqlConnection(strcon))
                {
                    con.Open();
                    var cmd = new MySqlCommand(query, con);
                    var resp = cmd.ExecuteReader();
                    while (resp.Read())
                    {
                        clients.Add(new Client
                        {
                            Id = resp.GetInt32(0),
                            Nome = resp.GetString(1).Split(' ')[0],
                            Username = resp.GetString(2),
                            Password = resp.GetString(3),
                            Email = resp.GetString(4),
                            Sobrenome = resp.GetString(1).Split(' ')[1],
                            Aniversario = resp.GetDateTime(5),
                            Endereco = resp.GetString(6),
                            Telefone = resp.GetString(7)
                        });
                    }
                    con.Close();
                }
                return clients;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void NewClient(Client client)
        {
            try
            {
                var query = "INSERT INTO client (name,username,password,email,birthday,address,phone) values (@name,@username,@password,@email,@birthday,@address,@phone)";
                using (MySqlConnection con = new MySqlConnection(strcon))
                {
                    con.Open();
                    var cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("name", client.Nome);
                    cmd.Parameters.AddWithValue("username", client.Username);
                    cmd.Parameters.AddWithValue("password", client.Password);
                    cmd.Parameters.AddWithValue("email", client.Email);
                    cmd.Parameters.AddWithValue("birthday", client.Aniversario);
                    cmd.Parameters.AddWithValue("address", client.Endereco);
                    cmd.Parameters.AddWithValue("phone", client.Telefone);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public bool UpdateClient(Client client)
        {
            var query = "UPDATE client SET name=@name,username=@username,password=@password,email=@email,birthday=@birthday,address=@address,phone=@phone WHERE idClient = @id";
            try
            {
                using (MySqlConnection con = new MySqlConnection(strcon))
                {
                    con.Open();
                    var cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("name", client.Nome);
                    cmd.Parameters.AddWithValue("username", client.Username);
                    cmd.Parameters.AddWithValue("password", client.Password);
                    cmd.Parameters.AddWithValue("email", client.Email);
                    cmd.Parameters.AddWithValue("birthday", client.Aniversario);
                    cmd.Parameters.AddWithValue("address", client.Endereco);
                    cmd.Parameters.AddWithValue("phone", client.Telefone);
                    cmd.Parameters.AddWithValue("id", client.Id);
                    cmd.Prepare();
                    con.Close();

                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public void DeleteClient(int id)
        {
            var query = "DELETE * FROM client WHERE idClient = @id";
            using (MySqlConnection con = new MySqlConnection(strcon))
            {
                con.Open();
                var cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("id", id);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                con.Close();
            }


        }
        #endregion

        #region Product
        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            var query = "SELECT * FROM products";
            using (MySqlConnection con = new MySqlConnection(strcon))
            {
                con.Open();
                var cmd = new MySqlCommand(query, con);
                var resp = cmd.ExecuteReader();

                while (resp.Read())
                {
                    products.Add(new Product
                    {
                        Id = resp.GetInt32(0),
                        Name = resp.GetString(1),
                        Price = resp.GetDouble(3),
                        Category = resp.GetString(4),
                        PathImages = GetPathImages(resp.GetInt32(0))
                    });
                };

                con.Close();

            }


            return products;
        }

        public void NewProduct(Product product)
        {
            var query = "INSERT INTO products (name,description,price,category) VALUES (@name,@description,@price,@category)";

            using (MySqlConnection con = new MySqlConnection(strcon))
            {
                con.Open();
                var cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("description", product.Description);
                cmd.Parameters.AddWithValue("price", product.Price);
                cmd.Parameters.AddWithValue("category", product.Category);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            if (product.PathImages.Count != 0) NewImages(product.PathImages, product.Name);


        }

        public bool UpdateProduct(Product product)
        {
            var query = "UPDATE products SET name=@name,description=@description,price=@price,category=@category WHERE idProduct = @id";
            try
            {
                using (MySqlConnection con = new MySqlConnection(strcon))
                {
                    con.Open();
                    var cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("name", product.Name);
                    cmd.Parameters.AddWithValue("description", product.Description);
                    cmd.Parameters.AddWithValue("price", product.Price);
                    cmd.Parameters.AddWithValue("category", product.Category);
                    cmd.Parameters.AddWithValue("idProduct", product.Id);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


        private void NewImages(List<string> pathImages, string name)
        {
            var query = "INSERT INTO images (productName,path) VALUES (@name,@path)";

            using (MySqlConnection con = new MySqlConnection(strcon))
            {
                con.Open();
                var cmd = new MySqlCommand(query, con);

                foreach (var path in pathImages)
                {
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("path", path);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                };
                con.Close();
            }
        }

        private List<string> GetPathImages(int idProduct)
        {
            var paths = new List<string>();
            var query = "SELECT Path FROM Images WHERE idProduct = @idProduct";
            using (MySqlConnection con = new MySqlConnection(strcon))
            {
                con.Open();
                var cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("idProduct", idProduct);
                cmd.Prepare();
                var resp = cmd.ExecuteReader();
                while (resp.Read())
                {
                    paths.Add(resp.GetString(0));
                }
                con.Close();
            }

            return paths;
        }
        public void DeleteProduct(int id)
        {
            var query = "DELETE * FROM products WHERE idProduct = @idProduct";
            using (MySqlConnection con = new MySqlConnection(strcon))
            {
                con.Open();
                var cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE * FROM Images WHERE idProduct = @idProduct";
                cmd.ExecuteNonQuery();
                con.Close();
            }


        }
        #endregion
    }
}