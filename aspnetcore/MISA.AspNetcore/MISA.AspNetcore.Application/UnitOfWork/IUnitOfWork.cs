using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AspNetcore.Application
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        DbConnection Connection { get; }

        DbTransaction? Transaction { get; }

        void BeginTransaction();

        Task BeginTransactionAsync();

        void Commit();

        Task CommitAsync();

        void RoolBack();

        Task RoolBackAsync();
    }
}
