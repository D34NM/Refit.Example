using Shows.Client.Contracts.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shows.Client
{
    public interface IShowsClient
    {
        Task<IEnumerable<Show>> GetPageAsync(int page, CancellationToken cancellationToken);

        Task<Show> SearchForShowAsync(string term, CancellationToken cancellationToken);
    }
}