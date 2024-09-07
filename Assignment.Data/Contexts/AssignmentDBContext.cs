using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Assignment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Data.Contexts
{
    public class AssignmentDBContext : DbContext
    {
        public AssignmentDBContext(DbContextOptions options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<BaseEntity>().HasQueryFilter(X => !X.IsDeleted);
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
