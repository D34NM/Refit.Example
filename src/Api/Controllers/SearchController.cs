using Microsoft.AspNetCore.Mvc;
using Shows.Client;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IShowsClient _showsClient;

        public SearchController(IShowsClient showsClient)
        {
            _showsClient = showsClient;
        }

        [HttpGet("{term}")]
        public async Task<IActionResult> Get(string term, CancellationToken cancellationToken)
        {
            var result = await _showsClient.SearchForShowAsync(term, cancellationToken);
            return Ok(result);
        }
    }
}
