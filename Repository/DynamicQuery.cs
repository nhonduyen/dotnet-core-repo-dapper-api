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
            foreach (var name in properties.Name)
            {
                if (name != "ID")
                {
                    columns.Add(name);
                }
            }
            return string.Format(@"INSERT INTO {0}({1}) OUTPUT inserted.ID VALUES({2})",
            tableName,
            string.Join(",", columns),
            string.Join(",@", columns));
        }
        public static string GetUpdateQuery(string tableName, dynamic item)
        {
            var properties = item.GetType().GetProperties();

            List<string> parameter = new List<string>();
            foreach (var name in properties.Name)
            {
                if (name != "ID")
                {
                    parameter.Add(name + "=@" + name);
                }
            }
            return string.Format(@"UPDATE {0} SET {1} WHERE ID=@ID",
            tableName, string.Join(",", parameter));
        }
      
    }
}