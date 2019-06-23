using Refit;
using Shows.Client.Contracts.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Shows.Client.Contracts
{
    public interface IShowSearchContract
    {
        [Get("/singlesearch/shows")]
        Task<Show> GetAsync([AliasAs("q")] string searchTerm, CancellationToken cancellationToken);
    }
}
