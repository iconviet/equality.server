using System.Reactive;
using Microsoft.AspNetCore.Components;
using ReactiveUI;

namespace Equality.Client.Models
{
    public class QuickSwapViewModel : ViewModelBase
    {
        public bool IsLoaded { get; set; }

        public string WalletAddress { get; set; }

        [Inject]
        public IconexWallet IconexWallet { get; set; }

        public ReactiveCommand<Unit, Unit> ConnectWallet { get; }

        public QuickSwapViewModel()
        {
            ConnectWallet = ReactiveCommand.CreateFromTask(async _ =>
            {
                WalletAddress = await IconexWallet.RequestAddressAsync();
            });
        }
    }
}