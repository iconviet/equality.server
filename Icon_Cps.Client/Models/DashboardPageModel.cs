using Icon_Cps.Client.Remote;

namespace Icon_Cps.Client.Models
{
    public class DashboardPageModel : PageModelBase
    {
        public JsonServiceClient ServiceClient { get; set; }
    }
}