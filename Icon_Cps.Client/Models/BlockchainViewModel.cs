using System;
using System.Reactive.Disposables;
using Icon_Cps.Client.Events;
using ReactiveUI;

namespace Icon_Cps.Client.Models
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