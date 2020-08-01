using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using IconCps.Blazor.Objects;

namespace IconCps.Blazor
{
    public class IconServiceClient
    {
        private readonly HttpClient _client;

        public IconServiceClient()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://ctz.solidwallet.io")
            };
        }

        public async Task<Block> GetLastBlockAsync()
        {
            var response = await _client.PostAsJsonAsync("api/v3", new
            {
                id = 12345,
                jsonrpc = "2.0",
                method = "icx_getLastBlock"
            });
            if (response.IsSuccessStatusCode)
            {
                return new Block { Height = 1 };
            }
            return new Block { Height = 0 };
        }
    }
}