using System;
using System.Reactive.Disposables;
using ReactiveUI;

namespace Icon_Cps.Client.Models
{
    public abstract class ModelBase : ReactiveObject, IDisposable
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