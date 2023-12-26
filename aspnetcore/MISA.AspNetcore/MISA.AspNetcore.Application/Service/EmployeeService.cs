using AutoMapper;
using MISA.AspNetcore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public class EmployeeService : BaseCrudService<Employee, Guid, EmployeeDto, EmployeeInsertDto, EmployeeUpdateDto>, IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeeManager _employeeManager;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper, IEmployeeManager employeeManager) : base(repository)
        {
            _employeeRepository = repository;
            _mapper = mapper;
            _employeeManager = employeeManager;
        }

        public async Task<bool> CheckDuplicationCodeAsync(string code)
        {
            var employee = await _employeeRepository.FindByCodeAsync(code);

            if(employee == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }


        public override async Task<Employee> MapEntityInsertDtoToEntity(EmployeeInsertDto employeeInsertDto)
        {
            await _employeeManager.CheckDuplicateCode(employeeInsertDto.EmployeeCode);

            var employeeInsert = _mapper.Map<EmployeeInsertDto, Employee>(employeeInsertDto);
            employeeInsert.EmployeeId = Guid.NewGuid();

            return employeeInsert;
        }

        public override async Task<Employee> MapEntityUpdateDtoToEntity(Guid id, EmployeeUpdateDto employeeUpdateDto)
        {
            var employee = await _employeeRepository.GetAsync(id);

            if (employee.EmployeeCode != employeeUpdateDto.EmployeeCode)
            {
                await _employeeManager.CheckDuplicateCode(employeeUpdateDto.EmployeeCode);
            }

            var employeeUpdate = _mapper.Map<EmployeeUpdateDto, Employee>(employeeUpdateDto);
            employeeUpdate.EmployeeId = id;

            
            return employeeUpdate;
        }

        public override EmployeeDto MapTEntityToTEntityDto(Employee employee)
        {
            var employeeDto = _mapper.Map<Employee, EmployeeDto>(employee);

            return employeeDto;
        }


        public override PageDataDto<EmployeeDto> MapPageDataToPageDataDto(PageData<Employee> entity)
        {
            

            var pageDataDto = new PageDataDto<EmployeeDto>
            {
                TotalPage = entity.TotalPage,
                TotalRecord = entity.TotalRecord,
                CurrentPage = entity.CurrentPage,
                CurrentPageRecords = entity.CurrentPageRecords,
                Data = entity.Data.Select(employee => MapTEntityToTEntityDto(employee)).ToList(),
            };

            return pageDataDto;
        }
    }
}