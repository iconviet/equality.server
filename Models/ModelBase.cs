using System;
using System.Reactive.Disposables;
using ReactiveUI;

namespace IconCps.Blazor.Models
{
    public abstract class ModelBase<T> : ReactiveObject, IDisposable
    {
        protected CompositeDisposable Composite { get; set; }

        protected ModelBase()
        {
            Composite = new CompositeDisposable();
        }

        public void Dispose()
        {
            Composite.Dispose();
        }
    }
}