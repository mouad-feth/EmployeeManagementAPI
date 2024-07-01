
using EmployeeManagementApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApi.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}