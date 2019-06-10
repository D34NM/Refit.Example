using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests
{
    public class SearchControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SearchControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact(DisplayName = "Should make 100 calls to the endpoint")]
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
