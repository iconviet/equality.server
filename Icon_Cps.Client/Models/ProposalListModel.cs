using System.Collections.Generic;
using Icon_Cps.Client.Objects;
using Icon_Cps.Client.Remote;

namespace Icon_Cps.Client.Models
{
    public class ProposalListModel : ModelBase
    {
        public List<Proposal> Proposals { get; set; }

        public IconServiceClient ServiceClient { get; set; }

        public ProposalListModel()
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