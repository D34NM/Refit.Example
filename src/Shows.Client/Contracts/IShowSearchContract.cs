using Refit;
using Shows.Client.Contracts.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Shows.Client.Contracts
{
    public interface IShowSearchContract
    {
        [Get("/singlesearch/shows?q={term}")]
        Task<Show> GetAsync(string term, CancellationToken cancellationToken);
    }
}
