using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;

namespace Equality.Client.Models
{
    public class AppBarViewModel : ViewModelBase
    {
        public string WalletAddress { get; set; }
        
        public bool IsRightDrawerOpen { get; set; }

        public bool IsLeftDrawerOpen { get; set; } = true;

        public IconexExtension IconexExtension { get; set; }

        public ReactiveCommand<Unit, Unit> ConnectWallet { get; }
        
        public ReactiveCommand<Unit, Unit> ToogleLeftDrawer { get; }

        public ReactiveCommand<Unit, Unit> ToogleRightDrawer { get; }

        public AppBarViewModel()
        {
            ToogleLeftDrawer = ReactiveCommand.CreateFromTask(() =>
            {
                IsLeftDrawerOpen = !IsLeftDrawerOpen;
                return Task.CompletedTask;
            });

            ToogleRightDrawer = ReactiveCommand.CreateFromTask(() =>
            {
                IsRightDrawerOpen = !IsRightDrawerOpen;
                return Task.CompletedTask;
            });

            ConnectWallet = ReactiveCommand.CreateFromTask(async _ =>
            {
                WalletAddress = await IconexExtension.RequestAddressAsync(JsRuntime);
            });
        }
    }
}