using Equality.Client.Remote;

namespace Equality.Client.Models
{
    public class HomePageModel : PageModelBase
    {
        public JsonServiceClient ServiceClient { get; set; }
    }
}