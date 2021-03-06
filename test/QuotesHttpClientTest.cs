using PipServices.Commons.Config;
using PipServices.Quotes.Client.Version1;

using System;

using Xunit;

namespace PipServices.Quotes.Client.Test
{
    // IMPORTANT: Before run this test - Please make sure that the microservice 
    // 'pip-services-quotes-dotnet' is up and running with memory persistence
    public class QuotesHttpClientTest : IDisposable
    {
        private static readonly ConfigParams RestConfig = ConfigParams.FromTuples(
            "connection.protocol", "http",
            "connection.host", "localhost",
            "connection.port", 8080
            );

        private readonly QuotesHttpClientV1 _client;
        private readonly QuotesClientFixture _fixture;

        public QuotesHttpClientTest()
        {
            _client = new QuotesHttpClientV1();
            _client.Configure(RestConfig);

            _fixture = new QuotesClientFixture(_client);

            var clientTask = _client.OpenAsync(null);
            clientTask.Wait();
        }

        [Fact]
        public void TestCrudOperations()
        {
            var task = _fixture.TestCrudOperations();
            task.Wait();
        }

        public void Dispose()
        {
            var task = _client.CloseAsync(null);
            task.Wait();
        }
    }
}
