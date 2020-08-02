using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Icon_Cps.Client.Objects;
using Icon_Cps.Client.Remote;

namespace Icon_Cps.Client.Models
{
    public class IndexModel : ModelBase
    {
        public long BlockHeight { get; set; }

        public List<Proposal> Proposals { get; set; }
        
        public JsonServiceClient ServiceClient { get; set; }

        public IndexModel()
        {
            Proposals = new List<Proposal>
            {
                new Proposal
                {
                    Title = "Proposal 1",
                    IcxRequested = 100000,
                    UsdRequested = 40000
                },
                new Proposal
                {
                    Title = "Proposal 2",
                    IcxRequested = 100000,
                    UsdRequested = 40000

                },
                new Proposal
                {
                    Title = "Proposal 3",
                    IcxRequested = 100000,
                    UsdRequested = 40000
                }
            };
            Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(async x =>
            {
                var block = await ServiceClient.GetLastBlock();
                BlockHeight = block.Height;
            }).DisposeWith(Composite);
        }
    }
}