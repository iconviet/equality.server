﻿using System.Reactive;
using Equality.Client.Remote;
using ReactiveUI;

namespace Equality.Client.Models
{
    public class PoolListPageModel : PageModelBase
    {
        public long Count { get; set; }

        public IconexExtension IconexExtension { get; set; }

        public IconServiceClient ServiceClient { get; set; }

        public ReactiveCommand<Unit, Unit> Increment { get; }

        public PoolListPageModel()
        {
            Increment = ReactiveCommand.CreateFromTask(async () =>
            {
                var block = await ServiceClient.GetLastBlock();
                Count = (long) block.GetHeight();
            });
        }
    }
}