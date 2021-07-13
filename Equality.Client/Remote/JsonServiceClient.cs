using Equality.Client.Objects;
using System;
using System.Threading.Tasks;

namespace Equality.Client.Remote
{
    public class JsonServiceClient
    {
        private readonly HttpClient _client;

        public JsonServiceClient()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://ctz.solidwallet.io")
            };
        }

        public async Task<Block> GetLastBlock()
        {
            var response = await _client.PostAsJsonAsync("/api/v3", new
            {
                id = 12345,
                jsonrpc = "2.0",
                method = "icx_getLastBlock"
            });
            return response != null ? new Block { Height = long.Parse(response.result.height) } : new Block { Height = 0 };
        }
    }
}