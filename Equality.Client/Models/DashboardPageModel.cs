using Equality.Client.Remote;

namespace Equality.Client.Models
{
    public class DashboardPageModel : PageModelBase
    {
        public JsonServiceClient ServiceClient { get; set; }
    }
}