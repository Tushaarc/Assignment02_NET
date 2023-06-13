using EmpMngmntSys.Models;

namespace EmpMngmntSys.Contracts
{
    public interface IEmployeeRepository
    {
        Task<Employees> GetAsync(int? employeeId);

        Task<List<Employees>> GetAllAsync();

        Task<Employees> CreateAsync(Employees employee);

        Task DeleteAsync(int employeeId);

        Task UpdateAsync(Employees employee);
    }
}
