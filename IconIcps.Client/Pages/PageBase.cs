using IconIcps.Client.Models;
using IconIcps.Client.Views;

namespace IconIcps.Client.Pages
{
    public abstract class PageBase<T> : ViewBase<T> where T : PageModelBase, new()
    {
        public string Title { get; set; }
    }
}