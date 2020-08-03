using IconIcps.Client.Remote;

namespace IconIcps.Client.Models
{
    public class DashboardPageModel : PageModelBase
    {
        public JsonServiceClient ServiceClient { get; set; }
    }
}