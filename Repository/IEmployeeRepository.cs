
using mydapper.Models;
using System.Threading.Tasks;

namespace mydapper.Repository
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        Task<Employee> FindEmpById(string id, string columns = "*");
    }
}