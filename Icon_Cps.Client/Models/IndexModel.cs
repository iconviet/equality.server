using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Icon_Cps.Client.Remote;

namespace Icon_Cps.Client.Models
{
    public class IndexModel : ModelBase<IndexModel>
    {
        public long BlockHeight { get; set; }

        public IndexModel()
        {
            Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(async x =>
            {
                var client = new JsonServiceClient();
                var block = await client.GetLastBlock();
                BlockHeight = block.Height;
            }).DisposeWith(Composite);
        }
    }
}