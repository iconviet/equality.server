using System.Reactive;
using ReactiveUI;

namespace Equality.Client.Models
{
    public class QuickSwapViewModel : ViewModelBase
    {
        public bool IsLoaded { get; set; }

        public string WalletAddress { get; set; }

        public IconexExtension IconexExtension { get; set; }

        public ReactiveCommand<Unit, Unit> ConnectWallet { get; }

        public QuickSwapViewModel()
        {
            ConnectWallet = ReactiveCommand.CreateFromTask(async _ =>
            {
                WalletAddress = await IconexExtension.RequestAddressAsync(JsRuntime);
            });
        }
    }
}