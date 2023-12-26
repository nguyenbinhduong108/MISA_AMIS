using AutoMapper;
using MISA.AspNetcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public class EmploteeProfile : Profile
    {
        public EmploteeProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            CreateMap<EmployeeInsertDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
        }
    }
}
