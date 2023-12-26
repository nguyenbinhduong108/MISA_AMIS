﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Domain
{
    public interface IEmployeeRepository : ICrudRepository<Employee, Guid>
    {
        Task<Employee?> FindByCodeAsync(string code);
    }
}