using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AspNetcore.Application;

namespace MISA.AspNetcore
{
    public class DepartmentsController : BaseReadOnlyController<Guid, DepartmentDto>
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService) : base(departmentService)
        {
            _departmentService = departmentService;
        }
    }
}
