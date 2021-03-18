using System;
using System.Reactive.Disposables;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ReactiveUI;

namespace Equality.Client.Models
{
    public abstract class ViewModelBase : ReactiveObject, IDisposable
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        protected CompositeDisposable Composite { get; set; }

        protected ViewModelBase()
        {
            Composite = new CompositeDisposable();
        }

        public virtual void Dispose()
        {
            Composite.Dispose();
        }
    }
}