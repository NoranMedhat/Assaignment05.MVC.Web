using Assignment.Data.Entities;
using Assignment.Service.Interfaces.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service.Interfaces.Employee
{
    public interface IEmployeeServices
    {
        EmployeeDto GetById(int? id);
        IEnumerable<EmployeeDto> GetAll();
        void Add(EmployeeDto employee);
        void Update(EmployeeDto employee);
        void Delete(EmployeeDto employee);
        IEnumerable<EmployeeDto> GetEmployeeByName(string name);
    }
}
