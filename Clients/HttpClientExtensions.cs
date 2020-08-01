using System.Net.Http;
using System.Threading.Tasks;
using ServiceStack;

namespace IconCps.Blazor.Clients
{
    public static class HttpClientExtensions
    {
        public static async Task<dynamic> PostAsJsonAsync(this HttpClient instance, string url, object rpc)
        {
            var content = new StringContent(rpc.ToJson());
            var response = await instance.PostAsync(url, content);
            return DynamicJson.Deserialize(await response.Content.ReadAsStringAsync());
        }
    }
}