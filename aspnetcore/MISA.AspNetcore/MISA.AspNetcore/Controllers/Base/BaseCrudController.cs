using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using MISA.AspNetcore.Application;

namespace MISA.AspNetcore
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseCrudController<TKey, TEntityDto, TEntityInsertDto, TEntityUpdateDto> : BaseReadOnlyController<TKey, TEntityDto> where TEntityDto : class where TEntityInsertDto : class where TEntityUpdateDto : class
    {

        public readonly ICrudService<TKey, TEntityDto, TEntityInsertDto, TEntityUpdateDto> CrudService;

        public BaseCrudController(ICrudService<TKey, TEntityDto, TEntityInsertDto, TEntityUpdateDto> crudService) : base(crudService)
        {
            CrudService = crudService;
        }


        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> FilterAsync(int? pageSize, int? pageNumber, string? search)
        {
            var result = await CrudService.FilterAsync(pageSize, pageNumber, search);

            return StatusCode(StatusCodes.Status200OK, result);

        }


        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <returns>Nhân viên</returns>
        /// Author: NBDUONG (11/08/2023)
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] TEntityInsertDto entity)
        {
            var result = await CrudService.InsertAsync(entity);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Sửa nhân viên
        /// </summary>
        /// <returns>Nhân viên</returns>
        /// Author: NBDUONG (11/08/2023)
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutAsync(TKey id, [FromBody] TEntityUpdateDto entity)
        {

            var result = await CrudService.UpdateAsync(id, entity);

            return StatusCode(StatusCodes.Status200OK, result);


        }

        /// <summary>
        /// Xoá 1 nhân viên
        /// </summary>
        /// <returns>Nhân viên</returns>
        /// Author: NBDUONG (11/08/2023)
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(TKey id)
        {
            var result = await CrudService.DeleteAsync(id);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Xoá nhiều nhân viên
        /// </summary>
        /// <returns>Nhân viên</returns>
        /// Author: NBDUONG (11/08/2023)
        [HttpDelete]
        public async Task<IActionResult> DeleteManyAsync(List<TKey> ids)
        {
            var result = await CrudService.DeleteManyAsync(ids);

            return StatusCode(StatusCodes.Status200OK,result);
        }
    }
}
