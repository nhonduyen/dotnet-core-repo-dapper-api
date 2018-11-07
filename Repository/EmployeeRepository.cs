using mydapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace mydapper.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
       public EmployeeRepository(string _tableName = "Employee"): base(_tableName)
       {
       }
        public async Task<Employee> FindEmpById(string id, string columns = "*")
        {
            using (IDbConnection cn = Connection)
            {
                var sql = string.Format("SELECT {0} FROM {1} WHERE EMP_ID=@ID;", columns, this._tableName);
                var result = await cn.QueryFirstAsync<Employee>(sql, new { ID = id });
                return result;
            }
        }
    }

}