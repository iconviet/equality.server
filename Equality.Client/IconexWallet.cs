using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Equality.Client
{
    public class IconexWallet : IDisposable
    {
        private string _address;

        private readonly IJSRuntime _jsruntime;

        private readonly DotNetObjectReference<IconexWallet> _dotnetobj;

        public IconexWallet(IJSRuntime jsruntime)
        {
            _jsruntime = jsruntime;
            _dotnetobj = DotNetObjectReference.Create(this);
        }

        [JSInvokable]
        public void ResponseAddressAsync(string address)
        {
            _address = address;
        }

        public async Task<string> RequestAddressAsync()
        {
            await _jsruntime.InvokeVoidAsync("request_address", _dotnetobj);
            return _address;
        }

        public async Task<string> RequestSigningAsync(string from, string hash)
        {
            return await _jsruntime.InvokeAsync<string>("request_signing", from, hash);
        }

        public void Dispose()
        {
            _dotnetobj.Dispose();
        }
    }
}