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
    }

}