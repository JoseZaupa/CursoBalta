using Blog.Models;
using Blog.Repositories;
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
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            //CreateUser();
            //ReadUsers(connection);
                ReadUsersWithRoles(connection);
           // CreateUser(connection);
            //ReadRoles(connection);
            //ReadTags(connection);
            //ReadUser();
            //UpdateUser();
            //DeleteUser();
            connection.Close();
        }
        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();
            foreach (var item in items)
            {
                 Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }        
           
        }
        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }

        }

        public static void CreateUser(SqlConnection connection)
        {
            var user = new User() 
            {
                Email = "email@balta.io",
                Bio = "bio",
                Image = "image",
                Name = "Name",
                PasswordHash = "hash",
                Slug = "slug"
            };
            var repository = new Repository<User>(connection);
            repository.Create(user);
            

        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }

        }
        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }

        }

    }
}
