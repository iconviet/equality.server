using System;
using System.Reactive.Disposables;
using Microsoft.JSInterop;
using ReactiveUI;

namespace Equality.Client.Models
{
    public abstract class ViewModelBase : ReactiveObject, IDisposable
    {
        public IJSRuntime JsRuntime { get; set; }
        
        protected CompositeDisposable Composite { get; set; }

        protected ViewModelBase()
        {
            Composite = new CompositeDisposable();
        }

        public void Dispose()
        {
            Composite.Dispose();
        }
    }
}