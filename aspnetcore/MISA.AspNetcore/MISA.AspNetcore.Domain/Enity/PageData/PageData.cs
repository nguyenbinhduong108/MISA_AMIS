using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Domain
{
    public class PageData<TEntity>
    {
        public int TotalPage { get; set; }
        public int TotalRecord { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentPageRecords { get; set; }
        public List<TEntity> Data { get; set; }
    }
}
