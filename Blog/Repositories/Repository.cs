﻿using Dapper.Contrib.Extensions;
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

        public T Get(int id)
          => _connection.Get<T>(id);

        public void Create(T model)
            => _connection.Insert<T>(model);
        
        public void Update(T model)
            => _connection.Update<T>(model);
        

        public void Deleter(T model)
            => _connection.Update<T>(model);
        
        public void Deleter(int id)
       {
            var model = _connection.Get<T>(id);
            _connection.Delete<T>(model);
        }
    }
}
