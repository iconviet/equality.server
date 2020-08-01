using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace IconCps.Blazor.Models
{
    public class IndexModel : ModelBase<IndexModel>
    {
        public long BlockHeight { get; set; }

        public IndexModel()
        {
            Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(async x =>
            {
                var client = new IconServiceClient();
                var block = await client.GetLastBlockAsync();
                BlockHeight = block.Height;
            }).DisposeWith(Composite);
        }
    }
}