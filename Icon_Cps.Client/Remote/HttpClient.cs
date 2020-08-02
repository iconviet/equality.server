using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Icon_Cps.Client.Remote
{
    public class HttpClient : System.Net.Http.HttpClient
    {
        public override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellation)
        {
            // TODO: remove this if CORs issue is fixed
            request.Content = new StringContent(await request.Content.ReadAsStringAsync(cancellation));
            return await base.SendAsync(request, cancellation);
        }
    }
}