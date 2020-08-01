using System;
using System.Net.Http;
using System.Threading.Tasks;
using IconCps.Blazor.Objects;

namespace IconCps.Blazor.Clients
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
            if (response != null)
            {
                return new Block { Height = long.Parse(response.result.height) };
            }
            return new Block { Height = 0 };
        }
    }
}