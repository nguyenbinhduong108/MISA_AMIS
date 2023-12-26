using MISA.AspNetcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public class PageDataDto<TEntityDto>
    {
        public int TotalPage { get; set; }
        public int TotalRecord { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentPageRecords { get; set; }
        public List<TEntityDto> Data { get; set; }
    }
}
