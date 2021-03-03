using System;
using System.Reactive;
using Equality.Client.Remote;
using ReactiveUI;

namespace Equality.Client.Models
{
    public class PoolListPageModel : PageModelBase
    {
        public long Count { get; set; }

        public IconexWallet IconexWallet { get; set; }

        public IconServiceClient ServiceClient { get; set; }

        public ReactiveCommand<Unit, Unit> Increment { get; }

        public PoolListPageModel()
        {
            Increment = ReactiveCommand.CreateFromTask(async () =>
            {
                var block = await ServiceClient.GetLastBlock();
                Count = (long) block.GetHeight();
                var address = await IconexWallet.RequestAddressAsync();
                Console.WriteLine("Address is " + address);
            });
        }
    }
}