using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public interface IEmployeeService : ICrudService<Guid ,EmployeeDto, EmployeeInsertDto, EmployeeUpdateDto>
    {
        Task<bool> CheckDuplicationCodeAsync(string code);
    }
}