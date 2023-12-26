using MISA.AspNetcore.Application;
using MISA.AspNetcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Infrastructure
{
    public class DepartmentRepository : BaseReadOnlyRepository<Department, Guid>, IDepartmentRepository
    {
        public DepartmentRepository(IUnitOfWork uow) : base(uow)
        {
        }

    }
}
