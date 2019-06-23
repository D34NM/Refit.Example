using Refit;

namespace Shows.Client.Contracts.Models
{
    public sealed class SearchRequestParams
    {
        [AliasAs("q")]
        public string SearchTerm { get; set; }
    }
}