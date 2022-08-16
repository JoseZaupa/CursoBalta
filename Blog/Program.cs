using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;

namespace Blog
{
    class Program
    {
        private const string  CONNECTION_STRING = @"Password=CaiBr12345;Persist Security Info=True;User ID = sa; Initial Catalog = Blog; Data Source = BR-JZAUPA-L03;Encrypt=False";
        static void Main(string[] args)
        {
            //CreateUser();
            //ReadUsers();
            //ReadUser();
            //UpdateUser();
            DeleteUser();
        }
        public static void ReadUsers()
        {
            using(var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }        
            }
        }
        public static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);
                Console.WriteLine(user.Name);
            }
        }
        public static void CreateUser()
        {
            var user = new User()
            {
                Bio = "8x Microsoft MVP",
                Email = "andre@balta.io",
                Image = "https://...",
                Name = "André Baltieri",
                PasswordHash = "HASH",
                Slug = "andre-baltieri"
            };
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user);
                Console.WriteLine("Cadastro realizado com sucesso.");
            }
        }
        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 1, 
                Bio = "Equipe | balta.io",
                Email = "hello@balta.io",
                Image = "https://...",
                Name = "Equipe de suporte balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Update<User>(user);
                Console.WriteLine("Atualização realizada com sucesso.");
            }
        }
        public static void DeleteUser()
        {
            
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);
                connection.Delete<User>(user);
                Console.WriteLine("Exclusão realizada com sucesso.");
            }
        }
    }
}
