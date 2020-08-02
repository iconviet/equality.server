using System.Reactive;
using Icon_Cps.Client.Remote;
using ReactiveUI;

namespace Icon_Cps.Client.Models
{
    public class SponsorListPageModel : PageModelBase
    {
        public long Count { get; set; }

        public IconServiceClient ServiceClient { get; set; }

        public ReactiveCommand<Unit, Unit> Increment { get; }

        public SponsorListPageModel()
        {
            Increment = ReactiveCommand.CreateFromTask(async () =>
            {
                var block = await ServiceClient.GetLastBlock();
                Count = (long) block.GetHeight();
            });
        }
    }
}