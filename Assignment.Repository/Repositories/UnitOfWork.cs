using Assignment.Data.Contexts;
using Assignment.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AssignmentDBContext _Context;

        public UnitOfWork(AssignmentDBContext Context)
        {
            _Context = Context;
            DepartmentRepository=new DepartmentRepository(Context);
            EmployeeRepository=new EmployeeRepository(Context);
        }

        public IDepartmentRepository DepartmentRepository { get; set ; }
        public IEmployeeRepository EmployeeRepository { get ; set; }

        public int Complete()
            =>_Context.SaveChanges();

    }
}
