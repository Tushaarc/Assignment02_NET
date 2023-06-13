using EmpMngmntSys.Contracts;
using EmpMngmntSys.Data;
using EmpMngmntSys.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace EmpMngmntSys.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EDMngmntContext _context;
        public DepartmentRepository(EDMngmntContext context)
        {
            this._context = context;
        }

        public async Task<List<Departments>> GetAllAsync()
        {
            return await _context.Set<Departments>().ToListAsync();
        }

        public async Task<Departments?> GetAsync(int? departmentId)
        {
            if (departmentId == null)
            {
                return null;
            }
            return await this._context.Departments.FindAsync(departmentId);
        }

        public async Task<Departments>CreateAsync(Departments department)
        {
            await this._context.AddAsync(department);
            await this._context.SaveChangesAsync();
            return department;
        }

        public async Task DeleteAsync(int departmentId)
        {
            var department = await GetAsync(departmentId);

            if (department is null)
            {
                throw new Exception($"DepartmentID {departmentId} is not found.");
            }
            this._context.Set<Departments>().Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Departments department)
        {
            _context.Update(department);
            await _context.SaveChangesAsync();
        }

    }
}
