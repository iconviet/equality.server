using System.Reactive;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ReactiveUI;

namespace Equality.Client.Models
{
    public class QuickSwapViewModel : ViewModelBase
    {
        public bool IsLoaded { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        public string WalletAddress { get; set; }

        public IconexWallet IconexWallet { get; set; }

        public ReactiveCommand<Unit, Unit> ConnectWallet { get; }

        public QuickSwapViewModel()
        {
            ConnectWallet = ReactiveCommand.CreateFromTask(async _ =>
            {
                WalletAddress = await IconexWallet.RequestAddressAsync(JsRuntime);
            });
        }
    }
}