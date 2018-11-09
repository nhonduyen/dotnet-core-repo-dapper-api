using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Text;
using System.Dynamic;

namespace mydapper.Repository
{
    public sealed class DynamicQuery
    {
        public static string GetInsertQuery(string tableName, dynamic item)
        {
            var properties = item.GetType().GetProperties();
            List<string> columns = new List<string>();
            foreach (var prop in properties)
            {
                if (!string.Equals(prop.Name, "id", StringComparison.OrdinalIgnoreCase))
                {
                    columns.Add(prop.Name.ToUpper());
                }
            }
            return string.Format(@"INSERT INTO {0}({1}) VALUES(@{2});",
            tableName,
            string.Join(",", columns),
            string.Join(",@", columns));
        }
        public static string GetUpdateQuery(string tableName, dynamic item, string customId = "ID")
        {
            var properties = item.GetType().GetProperties();

            List<string> parameter = new List<string>();
            foreach (var prop in properties)
            {
                if (!string.Equals(prop.Name, customId, StringComparison.OrdinalIgnoreCase))
                {
                    parameter.Add(prop.Name.ToUpper() + "=@" + prop.Name.ToUpper());
                }
            }
            return string.Format(@"UPDATE {0} SET {1} WHERE {2}=@{3};",
            tableName, string.Join(",", parameter), customId, customId);
        }

    }
}