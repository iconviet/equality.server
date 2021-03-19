using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using ReactiveUI;

namespace Equality.Client
{
    public class IconexWallet : ReactiveObject, IDisposable
    {
        public string Address { get; set; }

        private TaskCompletionSource<string> _awaiter;

        private readonly DotNetObjectReference<IconexWallet> _dotnetobj;

        public IconexWallet()
        {
            _dotnetobj = DotNetObjectReference.Create(this);
        }

        [JSInvokable]
        public void ResponseAddressAsync(string address)
        {
            Address = address;
            _awaiter.TrySetResult(Address);
        }

        public Task<string> RequestAddressAsync(IJSRuntime jsruntime)
        {
            _awaiter = new TaskCompletionSource<string>();
            jsruntime.InvokeVoidAsync("request_address", _dotnetobj);
            return _awaiter.Task;
        }

        public async Task<string> RequestSigningAsync(IJSRuntime jsruntime, string from, string hash)
        {
            return await jsruntime.InvokeAsync<string>("request_signing", from, hash);
        }

        public void Dispose()
        {
            _dotnetobj.Dispose();
        }
    }
}