using Assignment.Data.Contexts;
using Assignment.Data.Entities;
using Assignment.Repository.Interfaces;

namespace Assignment.Repository.Repositories
{
    public class EmployeeRepository :GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly AssignmentDBContext _context;

        public EmployeeRepository(AssignmentDBContext context):base(context) 
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        => _context.Employees.Where(X => 
        X.Name.Trim().ToLower().Contains(name.Trim().ToLower())||
         X.Email.Trim().ToLower().Contains(name.Trim().ToLower())||
         X.PhoneNumber.Trim().ToLower().Contains(name.Trim().ToLower())
        ).ToList();

        public IEnumerable<Employee> GetEmployeesByAddress(string address)
        {
            throw new NotImplementedException();
        }
    }
}
