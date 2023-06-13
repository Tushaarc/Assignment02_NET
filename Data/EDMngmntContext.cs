using EmpMngmntSys.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace EmpMngmntSys.Data
{
    public class EDMngmntContext : DbContext
    {
        public EDMngmntContext(DbContextOptions options) : base(options) { }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }

    }
}