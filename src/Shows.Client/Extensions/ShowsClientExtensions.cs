using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Refit;
using Shows.Client.Contracts;
using System;
using System.Net.Http;

namespace Shows.Client.Extensions
{
    public static class ShowsClientExtensions
    {
        private const int TooManyRequests = 429;
        private const int HowManyTimes = 3;

        public static IServiceCollection AddShowsClient(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUri = new Uri(configuration["TvMazeApi:BaseUri"]);
            Console.WriteLine(baseUri.ToString());

            var policy = Policy
                .HandleResult(IfTooManyRequests())
                .WaitAndRetryAsync(HowManyTimes, WithExponentialBackoff());

            services
                .AddHttpClient<IShowsContract>(client =>
                {
                    client.BaseAddress = baseUri;
                })
                .AddTypedClient(client => RestService.For<IShowsContract>(client))
                .AddPolicyHandler(policy);

            services
                .AddHttpClient<IShowSearchContract>(client =>
                {
                    client.BaseAddress = baseUri;
                })
                .AddTypedClient(client => RestService.For<IShowSearchContract>(client))
                .AddPolicyHandler(policy);

            services.AddTransient<IShowsClient, ShowsClient>();

            return services;
        }

        private static Func<HttpResponseMessage, bool> IfTooManyRequests()
        {
            return response => (int)response.StatusCode == TooManyRequests;
        }

        private static Func<int, TimeSpan> WithExponentialBackoff()
        {
            return attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt));
        }
    }
}
