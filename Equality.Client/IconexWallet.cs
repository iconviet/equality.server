using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using ReactiveUI;

namespace Equality.Client
{
    public class IconexWallet : ReactiveObject, IDisposable
    {
        public string Address { get; set; }

        private readonly IJSRuntime _jsruntime;

        private TaskCompletionSource<string> _awaiter;

        private readonly DotNetObjectReference<IconexWallet> _dotnetobj;

        public IconexWallet(IJSRuntime jsruntime)
        {
            _jsruntime = jsruntime;
            _dotnetobj = DotNetObjectReference.Create(this);
        }

        [JSInvokable]
        public void ResponseAddressAsync(string address)
        {
            Address = address;
            _awaiter.SetResult(Address);
        }

        public Task<string> RequestAddressAsync()
        {
            _awaiter = new TaskCompletionSource<string>();
            _jsruntime.InvokeVoidAsync("request_address", _dotnetobj);
            return _awaiter.Task;
        }

        public async Task<string> RequestSigningAsync(string from, string hash)
        {
            return await _jsruntime.InvokeAsync<string>("request_signing", from, hash);
        }

        public void Dispose()
        {
            _dotnetobj?.Dispose();
        }
    }
}