using System.Reactive;
using Icon_Cps.Client.Remote;
using ReactiveUI;

namespace Icon_Cps.Client.Models
{
    public class SponsorListModel : ModelBase<SponsorListModel>
    {
        public long Count { get; set; }

        public ReactiveCommand<Unit, Unit> Increment { get; }

        public SponsorListModel()
        {
            Increment = ReactiveCommand.CreateFromTask(async () =>
            {
                var client = new IconServiceClient();
                var block = await client.GetLastBlock();
                Count = (long) block.GetHeight();
            });
        }
    }
}