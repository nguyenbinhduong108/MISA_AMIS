using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public class PositionDto : BaseAuditDto
    {
        public Guid PositionId { get; set; }

        public string PositionName { get; set; }
    }
}
