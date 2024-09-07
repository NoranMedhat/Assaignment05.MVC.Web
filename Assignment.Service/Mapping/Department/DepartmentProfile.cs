using Assignment.Data.Entities;
using Assignment.Service.Interfaces.Department.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment.Service.Mapping
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {   
            CreateMap<Department,DepartmentDto>().ReverseMap();
        }
    }
}
