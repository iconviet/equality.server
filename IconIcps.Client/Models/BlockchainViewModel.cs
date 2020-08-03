using System;
using System.Reactive.Disposables;
using IconIcps.Client.Events;
using ReactiveUI;

namespace IconIcps.Client.Models
{
    public class BlockchainViewModel : ViewModelBase
    {
        public long BlockHeight { get; set; }

        public BlockchainViewModel()
        {
            MessageBus.Current
                .Listen<BlockchainEvent>()
                .Subscribe(x => BlockHeight = x.BlockHeight)
                .DisposeWith(Composite);
        }
    }
}