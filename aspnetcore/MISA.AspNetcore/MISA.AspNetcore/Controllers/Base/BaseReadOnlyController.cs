using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using MISA.AspNetcore.Application;

namespace MISA.AspNetcore
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseReadOnlyController<TKey, TEntityDto> : ControllerBase where TEntityDto : class
    {
        public readonly IReadOnlyService<TKey, TEntityDto> ReadOnlyService;

        protected BaseReadOnlyController(IReadOnlyService<TKey, TEntityDto> readOnlyService)
        {
            ReadOnlyService = readOnlyService;
        }

        /// <summary>
        /// Hàm lấy danh sách bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Author: NBDUONG (16/08/2023)
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            var result = await ReadOnlyService.GetAllAsync();

            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Lấy 1 bản ghi
        /// </summary>
        /// <returns>Nhân viên</returns>
        /// Author: NBDUONG (16/08/2023)
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(TKey id)
        {
            var result = await ReadOnlyService.GetAsync(id);

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
