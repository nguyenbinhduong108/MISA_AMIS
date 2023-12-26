using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public interface ICrudService<TKey, TEntityDto, TEntityInsertDto, TEntityUpdateDto> : IReadOnlyService<TKey, TEntityDto> where TEntityDto : class where TEntityInsertDto : class where TEntityUpdateDto : class
    {

        /// <summary>
        /// Hàm phân trang
        /// </summary>
        /// <param name="pageSize">Số lượng bản ghi 1 trang</param>
        /// <param name="pageNumber">Số trang</param>
        /// <param name="search">Thông tin cần tìm</param>
        /// <returns>Danh sách bản ghi</returns>
        Task<PageDataDto<TEntityDto>> FilterAsync(int? pageSize, int? pageNumber, string? search);

        /// <summary>
        /// Hàm thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi</param>
        /// <returns>Bản ghi</returns>
        /// Author: NBDUONG (15/08/2023)
        Task<TEntityDto> InsertAsync(TEntityInsertDto entityInsertDto);

        /// <summary>
        /// Hàm sửa 1 bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi cần sửa</param>
        /// <param name="entity">Thông tin bản ghi sửa</param>
        /// <returns>Bản ghi</returns>
        /// Author: NBDUONG (15/08/2023)
        Task<TEntityDto> UpdateAsync(TKey id, TEntityUpdateDto entityUpdateDto);

        /// <summary>
        /// Hàm xoá 1 bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi cần xoá</param>
        /// <returns>int</returns>
        /// Author: NBDUONG (15/08/2023)
        Task<int> DeleteAsync(TKey id);


        /// <summary>
        /// Hàm xoá nhiều bản ghi
        /// </summary>
        /// <param name="entityId">Danh sách id bản ghi cần xoá</param>
        /// <returns>int</returns>
        /// Author: NBDUONG (15/08/2023)
        Task<int> DeleteManyAsync(List<TKey> ids);
    }
}
