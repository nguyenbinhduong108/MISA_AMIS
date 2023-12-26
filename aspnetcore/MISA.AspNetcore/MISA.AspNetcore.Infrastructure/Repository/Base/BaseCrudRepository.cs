using Dapper;
using MISA.AspNetcore.Application;
using MISA.AspNetcore.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Infrastructure
{
    public abstract class BaseCrudRepository<TEntity, TKey> : BaseReadOnlyRepository<TEntity, TKey>, ICrudRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        protected BaseCrudRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var procedureName = $"Proc_{TableName}_Insert";

            var param = new DynamicParameters();

            Type entityType = typeof(TEntity);
            PropertyInfo[] properties = entityType.GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                param.Add($"p_{propertyInfo.Name}", propertyInfo.GetValue(entity));
            }

            await Uow.Connection.ExecuteAsync(sql: procedureName,
                                              param: param,
                                              commandType: CommandType.StoredProcedure,
                                              transaction: Uow.Transaction);

            return entity;

        }

        public async Task<TEntity> UpdateAsync(TEntity entity, TKey entityId)
        {
            var procedureName = $"Proc_{TableName}_Update";

            var param = new DynamicParameters();

            Type entityType = typeof(TEntity);
            PropertyInfo[] properties = entityType.GetProperties();

            param.Add($"p_{TableName}Id", entityId);

            foreach (PropertyInfo propertyInfo in properties)
            {
                param.Add($"p_{propertyInfo.Name}", propertyInfo.GetValue(entity));
            }

            

            await Uow.Connection.ExecuteAsync(sql: procedureName,
                                              param: param,
                                              commandType: CommandType.StoredProcedure,
                                              transaction: Uow.Transaction);

           

            return entity;
        }

        public async Task<int> DeleteAsync(TKey id)
        {
            var entity = await FindAsync(id);

            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy nhân viên cần xoá");
            }

            else
            {
                var sql = $"DELETE FROM {TableName} WHERE {TableName}Id = @entityId;";

                var param = new DynamicParameters();
                param.Add("@entityId", id);

                var result = await Uow.Connection.ExecuteAsync(sql, param, transaction: Uow.Transaction);

                return result;
            }
        }

        public async Task<int> DeleteManyAsync(List<TKey> ids)
        {
            var sql = $"DELETE FROM {TableName} WHERE {TableName}Id IN @entityIds;";

            var param = new DynamicParameters();
            param.Add("@entityIds", ids);

            var result = await Uow.Connection.ExecuteAsync(sql, param, transaction: Uow.Transaction);

            return result;
        }

        public async Task<PageData<TEntity>> FilterAsync(int? pageSize, int? pageNumber, string? search)
        {
            var procedureName = "Proc_Employee_Filter";
            var parameters = new DynamicParameters();


            if (!pageNumber.HasValue)
            {
                pageNumber = 1;
            }
            if (!pageSize.HasValue)
            {
                pageSize = 10;
            }
            if (search == null)
            {
                search = "";
            }

            parameters.Add("pageSize", pageSize);
            parameters.Add("pageNumber", pageNumber);
            parameters.Add("search", search);

            var mutil = await Uow.Connection.QueryMultipleAsync(sql: procedureName,
                                                                         param: parameters,
                                                                         commandType: CommandType.StoredProcedure,
                                                                         transaction: Uow.Transaction);

            var result = new PageData<TEntity>
            {
                TotalRecord = (await mutil.ReadAsync<int>()).Single(),
                TotalPage = (await mutil.ReadAsync<int>()).Single(),
                CurrentPage = (await mutil.ReadAsync<int>()).Single(),
                CurrentPageRecords = (await mutil.ReadAsync<int>()).Single(),
                Data = (await mutil.ReadAsync<TEntity>()).ToList(),
            };
            

            if (result.TotalRecord == 0)
            {
                result.Data = new List<TEntity> { };
            }


            return result;
        }
    }
}
