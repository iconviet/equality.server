using System;
using System.Reactive.Linq;
using IconIcps.Client.Events;
using IconIcps.Client.Remote;
using ReactiveUI;

namespace IconIcps.Client
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