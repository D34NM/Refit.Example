using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Shows.Client;

namespace Api.Controllers
{
    [Route("api/shows")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly IShowsClient _showsClient;

        public ShowsController(IShowsClient showsClient)
        {
            _showsClient = showsClient;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var result = await _showsClient.GetPageAsync(id, cancellationToken);
            return Ok(result);
        }
    }
}
