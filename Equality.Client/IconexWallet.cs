using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Equality.Client
{
    public class IconexWallet
    {
        private readonly IJSRuntime _jsruntime;

        public IconexWallet(IJSRuntime jsruntime)
        {
            _jsruntime = jsruntime;
        }

        public async Task<string> RequestAddressAsync()
        {
            return await _jsruntime.InvokeAsync<string>("request_address_async");
        }

        public async Task<string> RequestSigningAsync(string from, string hash)
        {
            return await _jsruntime.InvokeAsync<string>("request_signing_async", from, hash);
        }
    }
}