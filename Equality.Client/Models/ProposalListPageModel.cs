using System.Collections.Generic;
using Equality.Client.Objects;
using Equality.Client.Remote;

namespace Equality.Client.Models
{
    public class ProposalListPageModel : PageModelBase
    {
        public List<Proposal> Proposals { get; set; }

        public IconServiceClient ServiceClient { get; set; }

        public ProposalListPageModel()
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
        }
    }
}