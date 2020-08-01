using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace IconCps.Blazor.Pages
{
    public class PageBase : ComponentBase, IDisposable
    {
        [Inject]
        protected IconServiceClient IconService { get; set; }

        protected List<IDisposable> Subscriptions { get; } = new List<IDisposable>();

        public void Dispose()
        {
            foreach (var subscription in Subscriptions)
            {
                subscription.Dispose();
            }
            Subscriptions.Clear();
        }
    }
}