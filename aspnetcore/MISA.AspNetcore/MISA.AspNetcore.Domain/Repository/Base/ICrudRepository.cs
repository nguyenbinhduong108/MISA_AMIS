using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Domain
{
    public interface ICrudRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        /// <summary>
        /// Hàm phân trang
        /// </summary>
        /// <param name="pageSize">Số lượng bản ghi 1 trang</param>
        /// <param name="pageNumber">Số trang</param>
        /// <param name="search">Thông tin cần tìm</param>
        /// <returns>Danh sách bản ghi</returns>
        Task<PageData<TEntity>> FilterAsync(int? pageSize, int? pageNumber, string? search);

        /// <summary>
        /// Hàm thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi</param>
        /// <returns>Bản ghi được thêm</returns>
        /// Author: NBDUONG (16/08/2023)
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// Hàm sửa 1 bản ghi
        /// </summary>
        /// <param name="entityId">Id bản ghi cần sửa</param>
        /// <param name="entity">Thông tin bản ghi sửa</param>
        /// <returns>Bản ghi đã sửa</returns>
        /// Author: NBDUONG (16/08/2023)
        Task<TEntity> UpdateAsync(TEntity entity, TKey entityId);

        /// <summary>
        /// Hàm xoá 1 bản ghi
        /// </summary>
        /// <param name="entityId">Id bản ghi cần xoá</param>
        /// <returns>int</returns>
        /// Author: NBDUONG (16/08/2023)
        Task<int> DeleteAsync(TKey entityId);

        /// <summary>
        /// Hàm xoá nhiều bản ghi
        /// </summary>
        /// <param name="entityId">Danh sách id bản ghi cần xoá</param>
        /// <returns>int</returns>
        /// Author: NBDUONG (16/08/2023)
        Task<int> DeleteManyAsync(List<TKey> entityIds);
    }
}
