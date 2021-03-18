using System.Reactive.Disposables;
using Equality.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ReactiveUI.Blazor;

namespace Equality.Client.Views
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

        [Inject]
        public NavigationManager Navigation { get; set; }

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
                Composite.Dispose();
                ViewModel.Dispose();
            }
        }
    }
}