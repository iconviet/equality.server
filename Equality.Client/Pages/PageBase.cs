using Equality.Client.Models;
using Equality.Client.Views;

namespace Equality.Client.Pages
{
    public abstract class PageBase<T> : ViewBase<T> where T : PageModelBase, new()
    {
        public string Title { get; set; }
    }
}