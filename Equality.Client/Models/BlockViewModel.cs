using System;
using System.Reactive.Disposables;
using Equality.Client.Events;
using ReactiveUI;

namespace Equality.Client.Models
{
    public class BlockViewModel : ViewModelBase
    {
        public long Height { get; set; }

        public BlockViewModel()
        {
            MessageBus.Current.Listen<BlockEvent>().Subscribe(x => Height = x.Height).DisposeWith(Composite);
        }
    }
}