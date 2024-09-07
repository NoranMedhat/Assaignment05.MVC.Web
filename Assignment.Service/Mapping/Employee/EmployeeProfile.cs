using Assignment.Data.Entities;
using Assignment.Service.Interfaces.Employee.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service.Mapping
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee,EmployeeDto>().ReverseMap();
           // CreateMap<EmployeeDto, Employee>();

        }
    }
}
