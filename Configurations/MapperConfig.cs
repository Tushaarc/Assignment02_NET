﻿using AutoMapper;
using EmpMngmntSys.DTOs.Department;
using EmpMngmntSys.DTOs.Employee;
using EmpMngmntSys.Models;

namespace EmpMngmntSys.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Departments,
                GetDepartmentDto>().ReverseMap();
            CreateMap<Departments,
                UpdateDepartmentDto>().ReverseMap();
            CreateMap<Departments,
                GetDepartmentEmployeesDto>();
            CreateMap<Employees,
                EmployeeDto>().ReverseMap();
        }
    }
}
