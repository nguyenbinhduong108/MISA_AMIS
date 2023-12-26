using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public interface IDepartmentService : IReadOnlyService<Guid, DepartmentDto>
    {
    }
}
