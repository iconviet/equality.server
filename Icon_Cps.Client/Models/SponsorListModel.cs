using System.Reactive;
using Icon_Cps.Client.Remote;
using ReactiveUI;

namespace Icon_Cps.Client.Models
{
    public class SponsorListModel : ModelBase
    {
        public long Count { get; set; }

        public IconServiceClient ServiceClient { get; set; }

        public ReactiveCommand<Unit, Unit> Increment { get; }

        public SponsorListModel()
        {
            Increment = ReactiveCommand.CreateFromTask(async () =>
            {
                var block = await ServiceClient.GetLastBlock();
                Count = (long) block.GetHeight();
            });
        }
    }
}