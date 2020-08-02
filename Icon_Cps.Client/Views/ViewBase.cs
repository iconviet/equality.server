using System.Reactive.Disposables;
using Icon_Cps.Client.Models;
using ReactiveUI.Blazor;

namespace Icon_Cps.Client.Views
{
    public abstract class ViewBase<T> : ReactiveComponentBase<T> where T : ModelBase<T>, new()
    {
        protected CompositeDisposable Composite { get; set; }

        protected ViewBase()
        {
            Composite = new CompositeDisposable();
            ViewModel = new T();
            ViewModel.DisposeWith(Composite);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing) Composite.Dispose();
        }
    }
}