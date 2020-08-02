using System;
using System.Reactive.Disposables;
using Icon_Cps.Client.Events;
using ReactiveUI;

namespace Icon_Cps.Client.Models
{
    public class BlockchainModel : ModelBase
    {
        public long BlockHeight { get; set; }

        public BlockchainModel()
        {
            MessageBus.Current
                .Listen<BlockchainEvent>()
                .Subscribe(x => BlockHeight = x.BlockHeight)
                .DisposeWith(Composite);
        }
    }
}