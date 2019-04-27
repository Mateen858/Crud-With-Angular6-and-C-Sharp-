using System.Linq;
using CrudWithAngular6_Models.Classes;


namespace CrudWithAngular6_Contracts.IRepositories
{
    public interface IEmployeeRepository
    {
        bool Save(Employee employee);
        bool Delete(int id);
        IQueryable<Employee> GetAll();
    }
}
