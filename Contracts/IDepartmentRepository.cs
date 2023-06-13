using EmpMngmntSys.Models;

namespace EmpMngmntSys.Contracts
{
    public interface IDepartmentRepository
    {
        Task<Departments> GetAsync(int? DepartmentId);

        Task<List<Departments>> GetAllAsync();

        Task<Departments> CreateAsync(Departments department);

        Task DeleteAsync(int DepartmentId);

        Task UpdateAsync(Departments department);
    }
}
