using System;
using System.Reactive.Disposables;
using IconIcps.Client.Events;
using ReactiveUI;

namespace IconIcps.Client.Models
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