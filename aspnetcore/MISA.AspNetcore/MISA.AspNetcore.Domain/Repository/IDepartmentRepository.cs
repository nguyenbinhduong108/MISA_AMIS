using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Domain
{
    public interface IDepartmentRepository : IReadOnlyRepository<Department, Guid>
    {
    }
}