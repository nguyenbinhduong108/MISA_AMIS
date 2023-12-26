using MISA.AspNetcore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public class DepartmentDto : BaseAuditDto
    {
        [Required]
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
