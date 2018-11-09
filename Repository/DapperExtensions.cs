using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace mydapper.Repository
{
    public static class DapperExtensions
    {
        public static async Task<int> Insert<T>(this IDbConnection cnn, string tableName, dynamic items)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            return await SqlMapper.ExecuteAsync(cnn, DynamicQuery.GetInsertQuery(tableName, items),
             items);
        }
        public static async Task<int> Update<T>(this IDbConnection cnn, string tableName, 
        dynamic items, string customIdColumn = "ID")
        {
            return await SqlMapper.ExecuteAsync(cnn, DynamicQuery.GetUpdateQuery(tableName, items, customIdColumn),
             items);
        }
    }
}