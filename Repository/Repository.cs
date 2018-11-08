using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using Dapper;
using mydapper;

namespace mydapper.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected string _tableName { get; set; }
        private readonly string connectionString = Startup.ConnectionString;
        internal IDbConnection Connection
        {
            get
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
        }
        public Repository(string tableName)
        {
            this._tableName = tableName;
        }

        public virtual dynamic Mapping(T item)
        {
            return item;
        }
        public virtual async Task<int> Add(T item)
        {
            using (IDbConnection cn = this.Connection)
            {
                var parameters = (object)this.Mapping(item);
                return await cn.Insert<int>(this._tableName, parameters);
            }
        }
        public virtual async Task<int> Remove(int ID)
        {
            using (IDbConnection cn = this.Connection)
            {
                var sql = string.Format("DELETE FROM {0} WHERE ID=@ID", this._tableName);
                return await cn.ExecuteAsync(sql, ID).ConfigureAwait(false);
            }
        }
        public virtual async Task RemoveAll()
        {
            using (IDbConnection cn = this.Connection)
            {
                var sql = string.Format("TRUNCATE TABLE {0};", this._tableName);
                await cn.ExecuteAsync(sql).ConfigureAwait(false);
            }
        }
        public virtual async Task<int> Update(T item)
        {
            using (IDbConnection cn = this.Connection)
            {
                var parameters = (object)this.Mapping(item);
                return await cn.Update<int>(this._tableName, parameters);
            }
        }
        public virtual async Task<T> FindById(int id, string columns = "*")
        {
            using (IDbConnection cn = this.Connection)
            {
                var sql = string.Format("SELECT {0} FROM {1} WHERE ID=@ID;", columns, this._tableName);
                return await cn.QueryFirstOrDefaultAsync<T>(sql, new { ID = id }).ConfigureAwait(false);
            }
        }
        public virtual async Task<IEnumerable<T>> Find(string condition, object param = null, string columns = "*")
        {
            using (IDbConnection cn = this.Connection)
            {
                var sql = string.Format("SELECT {0} FROM {1} WHERE {2};", columns, this._tableName, condition);
                return await cn.QueryAsync<T>(sql, param).ConfigureAwait(false);
            }
        }
        public async Task<IEnumerable<T>> FindAll(string columns = "*")
        {
            var sql = string.Format(@"SELECT {0} FROM {1};", columns, this._tableName);
            using (IDbConnection cn = this.Connection)
            {
                return await cn.QueryAsync<T>(sql).ConfigureAwait(false);
            }
        }
    }
}