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
            ReadUsers(connection);
            ReadURoles(connection);
            //ReadUser();
            //UpdateUser();
            //DeleteUser();
            connection.Close();
        }
        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.Get();
            foreach (var user in users)
            {
                 Console.WriteLine(user.Name);
            }        
           
        }

        public static void ReadURoles(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);
            var roles = repository.Get();
            foreach (var role in roles)
            {
                Console.WriteLine(role.Name);
            }

        }

    }
}
