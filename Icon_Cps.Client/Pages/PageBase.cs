using Icon_Cps.Client.Models;
using Icon_Cps.Client.Views;

namespace Icon_Cps.Client.Pages
{
    public abstract class PageBase<T> : ViewBase<T> where T : PageModelBase, new()
    {
    }
}