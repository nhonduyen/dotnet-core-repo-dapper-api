using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace mydapper.Repository
{
    public static class DapperExtensions
    {
        public static async Task<T> Insert<T>(this IDbConnection cnn, string tableName, dynamic items)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            var result = await SqlMapper.QueryAsync(cnn, DynamicQuery.GetInsertQuery(tableName, items),
             items);
            return result.First();
        }
        public static async Task<int> Update<T>(this IDbConnection cnn, string tableName, dynamic items)
        {
            return await SqlMapper.ExecuteAsync(cnn, DynamicQuery.GetUpdateQuery(tableName, items),
             items);
        }
    }
}