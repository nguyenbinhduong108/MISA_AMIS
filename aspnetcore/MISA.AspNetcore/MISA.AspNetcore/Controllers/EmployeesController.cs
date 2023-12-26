using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AspNetcore.Application;

namespace MISA.AspNetcore
{
    public class EmployeesController : BaseCrudController<Guid, EmployeeDto, EmployeeInsertDto, EmployeeUpdateDto>
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("exist-code")]
        public async Task<bool> CheckExistCode(string code)
        {
            var result = await _employeeService.CheckDuplicationCodeAsync(code);

            return result;
        }
    }
} 