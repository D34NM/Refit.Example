using Shows.Client.Contracts.Models;
using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shows.Client.Contracts
{
    internal interface IShowsContract
    {
        [Get("/shows")]
        Task<IEnumerable<Show>> GetAsync(int page, CancellationToken cancellationToken);
    }
}
