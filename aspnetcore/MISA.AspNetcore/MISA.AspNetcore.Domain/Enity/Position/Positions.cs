using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Domain
{
    public class Positions : BaseAuditEntity, IEntity<Guid>
    {
        public Guid PositionId { get; set; }

        public string PositionName { get; set; }

        public Guid GetId()
        {
            return PositionId;
        }

        public void SetId(Guid id)
        {
            PositionId = id;
        }
    }
}
