using System.Reactive;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ReactiveUI;

namespace Equality.Client.Models
{
    public class AppBarViewModel : ViewModelBase
    {
        public bool IsOpen { get; set; }

        public string WalletAddress { get; set; }

        [Inject]
        public IconexWallet IconexWallet { get; set; }

        public ReactiveCommand<Unit, Unit> ToogleOpen { get; }

        public ReactiveCommand<Unit, Unit> RequestAddress { get; }

        public AppBarViewModel()
        {
            ToogleOpen = ReactiveCommand.CreateFromTask(() =>
            {
                IsOpen = !IsOpen;
                return Task.CompletedTask;
            });

            RequestAddress = ReactiveCommand.CreateFromTask(async _ =>
            {
                WalletAddress = await IconexWallet.RequestAddressAsync();
            });
        }
    }
}