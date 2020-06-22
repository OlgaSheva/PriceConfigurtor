using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PriceConfigurator.DataAccess
{
    public interface IAsyncEntityStorage
    {
        Task<int> SaveChangesAsync();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}