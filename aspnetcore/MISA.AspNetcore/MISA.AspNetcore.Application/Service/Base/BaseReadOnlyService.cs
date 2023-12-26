using MISA.AspNetcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public abstract class BaseReadOnlyService<TEntity, TKey, TEntityDto> : IReadOnlyService<TKey, TEntityDto> where TEntity : IEntity<TKey> where TEntityDto : class
    {

        public readonly IReadOnlyRepository<TEntity, TKey> ReadOnlyRepository;

        public BaseReadOnlyService(IReadOnlyRepository<TEntity, TKey> repository)
        {
            ReadOnlyRepository = repository;
        }

        public async Task<List<TEntityDto>> GetAllAsync()
        {
            var entities = await ReadOnlyRepository.GetAllAsync();

            var result = entities.Select(entity => MapTEntityToTEntityDto(entity)).ToList();

            return result;
        }

        public async Task<TEntityDto> GetAsync(TKey id)
        {
            var entity = await ReadOnlyRepository.GetAsync(id);

            var result = MapTEntityToTEntityDto(entity);

            return result;
        }

        public abstract TEntityDto MapTEntityToTEntityDto(TEntity entity);
    }
}
