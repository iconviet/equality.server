using Microsoft.JSInterop;

namespace Equality.Client.Models
{
    public abstract class PageModelBase : ViewModelBase
    {
        public IJSRuntime JsRuntime { get; set; }
    }
}