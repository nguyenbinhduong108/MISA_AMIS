using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Domain
{
    public interface IReadOnlyRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Bản ghi</returns>
        /// Author: NBDUONG (16/08/2023)
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Hàm lấy 1 bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi</param>
        /// <returns>Bản ghi</returns>
        /// Author: NBDUONG (16/08/2023)
        Task<TEntity> GetAsync(TKey id);


        /// <summary>
        /// Tìm 1 bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi cần tìm</param>
        /// <returns>Bản ghi</returns>
        /// Author: NBDUONG (16/08/2023)
        Task<TEntity?> FindAsync(TKey id);
    }
}
