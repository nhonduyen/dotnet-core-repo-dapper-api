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
        public IOptions<SiteConfig> _config { get; set; }
        private readonly string connectionString = "Server=.\\SQLEXPRESS;Database=MBO;Trusted_Connection=True;";
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
                var id = await cn.Insert<int>(this._tableName, parameters);
                return id;
            }
        }
        public virtual async Task<int> Remove(int ID)
        {
            using (IDbConnection cn = this.Connection)
            {
                var sql = string.Format("DELETE FROM {0} WHERE ID=@ID", this._tableName);
                var result = await cn.ExecuteAsync(sql, ID);
                return result;
            }
        }
        public virtual async Task RemoveAll()
        {
            using (IDbConnection cn = this.Connection)
            {
                var sql = string.Format("TRUNCATE TABLE {0};", this._tableName);
                await cn.ExecuteAsync(sql);
            }
        }
        public virtual async Task<int> Update(T item)
        {
            using (IDbConnection cn = this.Connection)
            {
                var parameters = (object)this.Mapping(item);
                var result = await cn.Update<int>(this._tableName, parameters);
                return result;
            }
        }
        public virtual async Task<T> FindById(int id, string columns = "*")
        {
            using (IDbConnection cn = this.Connection)
            {
                var sql = string.Format("SELECT {0} FROM {1} WHERE ID=@ID;", columns, this._tableName);
                var result = await cn.QueryFirstOrDefaultAsync<T>(sql, new { ID = id });
                return result;
            }
        }
        public virtual async Task<IEnumerable<T>> Find(string condition, object param = null, string columns = "*")
        {
            using (IDbConnection cn = this.Connection)
            {
                var sql = string.Format("SELECT {0} FROM {1} WHERE {2};", columns, this._tableName, condition);
                var result = await cn.QueryAsync<T>(sql, param);
                return result;
            }
        }
        public async Task<IEnumerable<T>> FindAll(string columns = "*")
        {
            IEnumerable<T> items = null;

            var sql = string.Format(@"SELECT {0} FROM {1};", columns, this._tableName);
            using (IDbConnection cn = this.Connection)
            {
                items = await cn.QueryAsync<T>(sql);
            }
            return items;
        }
    }
}