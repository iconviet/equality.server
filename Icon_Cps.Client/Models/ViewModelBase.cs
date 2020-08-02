using System;
using System.Reactive.Disposables;
using ReactiveUI;

namespace Icon_Cps.Client.Models
{
    public abstract class ViewModelBase : ReactiveObject, IDisposable
    {
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