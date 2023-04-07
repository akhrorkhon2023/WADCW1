using Microsoft.EntityFrameworkCore;
using WADProject.Models;

namespace WADProject.Constants
{
    public class DbConstant : DbContext
    {
        public DbConstant(DbContextOptions<DbConstant> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; } = default!;
        public DbSet<Department> Departments { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasOne(d => d.Department).WithMany(e=>e.Employees).HasForeignKey(d => d.DepartmentId);
        }

    }
}
