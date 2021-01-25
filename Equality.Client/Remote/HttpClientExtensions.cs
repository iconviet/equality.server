using System.Net.Http.Json;
using System.Threading.Tasks;
using ServiceStack;

namespace Equality.Client.Remote
{
    public static class HttpClientExtensions
    {
        public static async Task<dynamic> PostAsJsonAsync(this HttpClient instance, string url, object rpc)
        {
            var response = await HttpClientJsonExtensions.PostAsJsonAsync(instance, url, rpc);
            return DynamicJson.Deserialize(await response.Content.ReadAsStringAsync());
        }
    }
}