using Assignment.Data.Entities;
using Assignment.Repository.Interfaces;
using Assignment.Service.Interfaces.Department;
using Assignment.Service.Interfaces.Department.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new DepartmentDto
            //{
            //    Code = department.Code,
            //    Name = department.Name,
            //    CreateAt = DateTime.Now,

            //};
            var mappedDepartment= _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Add(mappedDepartment);
            _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            var mappedDepartment = _mapper.Map<Department>(departmentDto);

            _unitOfWork.DepartmentRepository.Delete(mappedDepartment);
            _unitOfWork.Complete();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {

            var department = _unitOfWork.DepartmentRepository.GetAll();
            var mappedDepartment = _mapper.Map<IEnumerable<DepartmentDto>>(department);
            return mappedDepartment;

        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
                throw new Exception("id is null");
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if (department == null)
                return null;
            var mappedDepartment = _mapper.Map<DepartmentDto>(department);
            return mappedDepartment;

        }

        public void Update(DepartmentDto department)
        {

            //_unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.Complete();
        }
    }
}
