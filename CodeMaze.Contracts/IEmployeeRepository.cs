using CodeMaze.Entities.Models;
using CodeMaze.Shared;

namespace CodeMaze.Contracts
{
    public interface IEmployeeRepository
    {
        Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters parameters, bool trackChanges);

        Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);

        void CreateEmployeeForCompany(Guid companyId, Employee employee);

        void DeleteEmployee(Employee employee);
    }
}
