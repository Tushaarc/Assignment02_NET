using EmpMngmntSys.Contracts;
using EmpMngmntSys.Data;
using EmpMngmntSys.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace EmpMngmntSys.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EDMngmntContext _context;
        public EmployeeRepository(EDMngmntContext context)
        {
            this._context = context;
        }

        public async Task<List<Employees>> GetAllAsync()
        {
            return await _context.Set<Employees>().ToListAsync();
        }

        public async Task<Employees?> GetAsync(int? employeeId)
        {
            if (employeeId == null)
            {
                return null;
            }
            return await this._context.Employees.FindAsync(employeeId);
        }

        public async Task<Employees> CreateAsync(Employees employee)
        {
            await this._context.AddAsync(employee);
            await this._context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteAsync(int employeeId)
        {
            var employee = await GetAsync(employeeId);

            if (employee is null)
            {
                throw new Exception($"EmployeeID {employeeId} is not found.");
            }
            this._context.Set<Employees>().Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employees employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

    }
}
