using AutoMapper;
using MISA.AspNetcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public class DepartmentService : BaseReadOnlyService<Department, Guid, DepartmentDto>, IDepartmentService
    {

        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository repository, IMapper mapper) : base(repository)
        {
            _departmentRepository = repository;
            _mapper = mapper;
        }

        public override DepartmentDto MapTEntityToTEntityDto(Department department)
        {
            var departmentDto = _mapper.Map<Department, DepartmentDto>(department);

            return departmentDto;
        }
    }
}
