using Assignment.Data.Contexts;
using Assignment.Data.Entities;
using Assignment.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repository.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly AssignmentDBContext _context;

        public DepartmentRepository(AssignmentDBContext context):base(context) 
        {
            _context = context;
        }

        //public void Add(Department department)
        //=>_context.Add(department);

        //public void Delete(Department department)
        //=>_context.Remove(department);

        //public IEnumerable<Department> GetAll()
        //=> _context.Departments.ToList();

        //public Department GetById(int id)
        //=> _context.Departments.FirstOrDefault(X => X.Id == id);

        //public void Update(Department department)
        //=>_context.Update(department);
    }
}
