using System;
using System.Collections.Generic;
using IconCps.Blazor.Models;
using Microsoft.AspNetCore.Components;
using ReactiveUI.Blazor;

namespace IconCps.Blazor.Views
{
    public abstract class ViewBase<T> : ReactiveComponentBase<T> where T : ModelBase<T>, new()
    {
        [Inject]
        protected IconServiceClient IconService { get; set; }

        protected List<IDisposable> Subscriptions { get; set; }

        protected ViewBase()
        {
            ViewModel = new T();
            Subscriptions = new List<IDisposable>();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                foreach (var subscription in Subscriptions)
                {
                    subscription.Dispose();
                }
                Subscriptions.Clear();
            }
        }
    }
}