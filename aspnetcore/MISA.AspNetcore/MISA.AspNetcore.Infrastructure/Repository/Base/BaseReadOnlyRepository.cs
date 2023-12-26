using Dapper;
using MISA.AspNetcore.Application;
using MISA.AspNetcore.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Infrastructure
{
    public abstract class BaseReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {

        protected readonly IUnitOfWork Uow;
        protected virtual string TableName { get; set; } =  typeof (TEntity).Name;

        protected BaseReadOnlyRepository(IUnitOfWork uow)
        {
            Uow = uow;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {

            var procedureName = $"Proc_{TableName}_GetAll";

            var result = await Uow.Connection.QueryAsync<TEntity>(
                sql: procedureName,
                transaction: Uow.Transaction,
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            var entity = await FindAsync(id);

            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy nhân viên cần tìm");
            }

            return entity;
        }

        public async Task<TEntity?> FindAsync(TKey id)
        {
            var sql = $"SELECT * FROM {TableName} WHERE {TableName}Id = @id;";

            var param = new DynamicParameters();
            param.Add("@id", id);

            var result = await Uow.Connection.QuerySingleOrDefaultAsync<TEntity>(sql, param, transaction: Uow.Transaction);

            return result;
        }
    }
}
