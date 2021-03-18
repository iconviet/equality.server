using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;

namespace Equality.Client.Models
{
    public class AppBarViewModel : ViewModelBase
    {
        public bool IsOpen { get; set; }

        public string WalletAddress { get; set; }

        public IconexWallet IconexWallet { get; set; }

        public ReactiveCommand<Unit, Unit> ToogleOpen { get; }

        public ReactiveCommand<Unit, Unit> ConnectWallet { get; }

        public AppBarViewModel()
        {
            ToogleOpen = ReactiveCommand.CreateFromTask(() =>
            {
                IsOpen = !IsOpen;
                return Task.CompletedTask;
            });

            ConnectWallet = ReactiveCommand.CreateFromTask(async _ =>
            {
                WalletAddress = await IconexWallet.RequestAddressAsync(JsRuntime);
            });
        }
    }
}