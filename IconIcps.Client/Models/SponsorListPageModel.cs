using System;
using System.Reactive;
using IconIcps.Client.Remote;
using ReactiveUI;

namespace IconIcps.Client.Models
{
    public class SponsorListPageModel : PageModelBase
    {
        public long Count { get; set; }

        public IconexWallet IconexWallet { get; set; }

        public IconServiceClient ServiceClient { get; set; }

        public ReactiveCommand<Unit, Unit> Increment { get; }

        public SponsorListPageModel()
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