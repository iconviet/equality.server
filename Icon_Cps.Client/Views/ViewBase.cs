using System.Reactive.Disposables;
using Icon_Cps.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ReactiveUI.Blazor;

namespace Icon_Cps.Client.Views
{
    public abstract class ViewBase<T> : ReactiveComponentBase<T> where T : ViewModelBase, new()
    {
        [Inject]
        public new T ViewModel
        {
            get => base.ViewModel;
            set => base.ViewModel = value;
        }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        protected CompositeDisposable Composite { get; set; }

        protected ViewBase()
        {
            Composite = new CompositeDisposable();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                ViewModel.Dispose();
                Composite.Dispose();
            }
        }
    }
}