﻿using System.Reactive;
using IconCps.Blazor.Clients;
using ReactiveUI;

namespace IconCps.Blazor.Models
{
    public class SponsorListModel : ModelBase<SponsorListModel>
    {
        public long Count { get; set; }

        public ReactiveCommand<Unit, Unit> Increment { get; }

        public SponsorListModel()
        {
            Increment = ReactiveCommand.CreateFromTask(async () =>
            {
                var client = new IconServiceClient();
                var block = await client.GetLastBlock();
                Count = (long) block.GetHeight();
            });
        }
    }
}