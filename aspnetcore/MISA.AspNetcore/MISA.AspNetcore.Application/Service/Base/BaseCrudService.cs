using Microsoft.VisualBasic;
using MISA.AspNetcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public abstract class BaseCrudService<TEntity, TKey, TEntityDto, TEntityInsertDto, TEntityUpdateDto> : BaseReadOnlyService<TEntity, TKey, TEntityDto>, ICrudService<TKey, TEntityDto, TEntityInsertDto, TEntityUpdateDto> where TEntityDto : class where TEntityInsertDto : class where TEntityUpdateDto : class where TEntity : IEntity<TKey>
    {
        public readonly ICrudRepository<TEntity, TKey> CrudRepository;

        public BaseCrudService(ICrudRepository<TEntity, TKey> repository) : base(repository)
        {
            CrudRepository = repository;
        }


        public async Task<PageDataDto<TEntityDto>> FilterAsync(int? pageSize, int? pageNumber, string? search)
        {

            var entitiy = await CrudRepository.FilterAsync(pageSize, pageNumber, search);

            var result = MapPageDataToPageDataDto(entitiy);

            return result;
        }

        public async Task<TEntityDto> InsertAsync(TEntityInsertDto entityInsertDto)
        {
            var entity = await MapEntityInsertDtoToEntity(entityInsertDto);

            await CrudRepository.InsertAsync(entity);

            var result = MapTEntityToTEntityDto(entity);

            return result;


        }

        public async Task<TEntityDto> UpdateAsync(TKey id, TEntityUpdateDto entityUpdateDto)
        {
            var entity = await MapEntityUpdateDtoToEntity(id,entityUpdateDto);

            await CrudRepository.UpdateAsync(entity, id);

            var result = MapTEntityToTEntityDto(entity);

            return result;
        }

        public async Task<int> DeleteAsync(TKey id)
        {
            var entity = await CrudRepository.DeleteAsync(id);

            return entity;
        }

        public async Task<int> DeleteManyAsync(List<TKey> ids)
        {
            var entity = await CrudRepository.DeleteManyAsync(ids);

            return entity;
        }

        public abstract Task<TEntity> MapEntityInsertDtoToEntity(TEntityInsertDto entityInsertDto);

        public abstract Task<TEntity> MapEntityUpdateDtoToEntity(TKey id,TEntityUpdateDto entityUpdateDto);

        public abstract PageDataDto<TEntityDto> MapPageDataToPageDataDto(PageData<TEntity> entity);
    }
}
