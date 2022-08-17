using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories
{
   public class Repository<T> where T : class
   {
        private readonly SqlConnection _connection;
        public Repository(SqlConnection connection)
            =>  _connection = connection;

        public IEnumerable<T> Get()
           => _connection.GetAll<T>();
    }
}
