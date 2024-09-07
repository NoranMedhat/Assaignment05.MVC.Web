using Assignment.Data.Entities;
using Assignment.Repository.Interfaces;
using Assignment.Service.Helper;
using Assignment.Service.Interfaces.Employee;
using Assignment.Service.Interfaces.Employee.Dto;
using AutoMapper;
using System.Collections.Generic;

namespace Assignment.Service.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
           _mapper = mapper;
        }

        public void Add(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee()
            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    HiringDate = employeeDto.HiringDate,
            //    ImgUrl = employeeDto.ImgUrl,
            //    Name = employeeDto.Name,
            //    Salary = employeeDto.Salary,
            //    PhoneNumber = employeeDto.PhoneNumber

            //};
            employeeDto.ImgUrl =DocumentSetting.UploadFile(employeeDto.Image,"Images");
            Employee employee=_mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee()
            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    HiringDate = employeeDto.HiringDate,
            //    ImgUrl = employeeDto.ImgUrl,
            //    Name = employeeDto.Name,
            //    Salary = employeeDto.Salary,
            //    PhoneNumber = employeeDto.PhoneNumber

            //};
            Employee employee = _mapper.Map<Employee>(employeeDto);

            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            //var mappedEmployee = employees.Select(x => new EmployeeDto
            //{
            //    DepartmentId=x.DepartmentId,
            //    Email=x.Email,
            //    HiringDate=x.HiringDate,
            //    ImgUrl=x.ImgUrl,
            //    Name = x.Name,
            //    Salary=x.Salary,
            //    PhoneNumber=x.PhoneNumber,
            //    Id=x.Id,
            //    Address=x.Address,
            //    Age=x.Age,
            //    CreateAt=x.CreateAt

            //});
            IEnumerable<EmployeeDto> mappedEmployee = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return mappedEmployee;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id is null)
                return null;
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee is null)
                return null;
            
            //EmployeeDto employeeDto = new EmployeeDto()
            //{
            //    Address = employee.Address,
            //    Age = employee.Age,
            //    DepartmentId = employee.DepartmentId,
            //    Email = employee.Email,
            //    HiringDate = employee.HiringDate,
            //    ImgUrl = employee.ImgUrl,
            //    Name = employee.Name,
            //    Salary = employee.Salary,
            //    PhoneNumber = employee.PhoneNumber,
            //    Id = employee.Id,


            //};
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var employees = _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            //var mappedEmployee = employees.Select(x => new EmployeeDto
            //{
            //    DepartmentId = x.DepartmentId,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    ImgUrl = x.ImgUrl,
            //    Name = x.Name,
            //    Salary = x.Salary,
            //    PhoneNumber = x.PhoneNumber,
            //    Id = x.Id,
            //    Address = x.Address,
            //    Age = x.Age,
            //    CreateAt = x.CreateAt

            //});
            IEnumerable < EmployeeDto > mappedEmployee = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return mappedEmployee;


        }

        public void Update(EmployeeDto employee)
        {
            //_unitOfWork.EmployeeRepository.Update(employee);  
            _unitOfWork.Complete();
        }
    }
}
