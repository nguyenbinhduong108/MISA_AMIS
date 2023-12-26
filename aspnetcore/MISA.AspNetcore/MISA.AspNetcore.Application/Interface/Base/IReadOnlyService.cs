using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public interface IReadOnlyService<TKey, TEntityDto> where TEntityDto : class
    {
        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Bản ghi</returns>
        /// Author: NBDUONG (15/08/2023)
        Task<List<TEntityDto>> GetAllAsync();


        /// <summary>
        /// Hàm lấy 1 bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi</param>
        /// <returns>Bản ghi</returns>
        /// Author: NBDUONG (15/08/2023)
        Task<TEntityDto> GetAsync(TKey id);
    }
}
