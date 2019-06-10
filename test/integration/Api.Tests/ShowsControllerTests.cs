using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net;

namespace Api.Tests
{
    public class ShowsControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ShowsControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact(DisplayName = "Should make 11 calls to the endpoint")]
        public async Task Test1()
        {
            var client = _factory.CreateClient();

            for (int attempt = 1; attempt <= 100; attempt++)
            {
                var response = await client.GetAsync($"api/shows/{attempt}");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
