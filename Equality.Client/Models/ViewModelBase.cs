using System;
using System.Reactive.Disposables;
using ReactiveUI;

namespace Equality.Client.Models
{
    public abstract class ViewModelBase : ReactiveObject, IDisposable
    {
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