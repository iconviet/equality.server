using System;
using System.Reactive.Linq;
using Icon_Cps.Client.Events;
using Icon_Cps.Client.Remote;
using ReactiveUI;

namespace Icon_Cps.Client
{
    public static class BackgroundJob
    {
        public static void Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(async x =>
            {
                var client = new JsonServiceClient();
                var block = await client.GetLastBlock();
                MessageBus.Current.SendMessage(new BlockchainEvent { BlockHeight = block.Height });
            });
        }
    }
}