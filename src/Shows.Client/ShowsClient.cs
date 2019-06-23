using Shows.Client.Contracts;
using Shows.Client.Contracts.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shows.Client
{
    internal sealed class ShowsClient : IShowsClient
    {
        private readonly IShowsContract _showsApi;
        private readonly IShowSearchContract _showSearchContract;

        public ShowsClient(IShowsContract showsApi, IShowSearchContract showSearchContract)
        {
            _showsApi = showsApi;
            _showSearchContract = showSearchContract;
        }

        public async Task<IEnumerable<Show>> GetPageAsync(int page, CancellationToken cancellationToken)
        {
            return await _showsApi.GetAsync(page, cancellationToken);
        }

        public async Task<Show> SearchForShowAsync(string term, CancellationToken cancellationToken)
        {
            return await _showSearchContract.GetAsync(new SearchRequestParams { SearchTerm = term }, cancellationToken);
        }
    }
}
