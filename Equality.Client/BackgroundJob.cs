﻿using Equality.Client.Events;
using Equality.Client.Remote;
using ReactiveUI;
using System;
using System.Reactive.Linq;

namespace Equality.Client
{
    public static class BackgroundJob
    {
        public static void Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(async x =>
            {
                try
                {
                    var client = new JsonServiceClient();
                    var block = await client.GetLastBlock();
                    MessageBus.Current.SendMessage(new BlockEvent { Height = block.Height });
                }
                catch
                {
                }
            });
        }
    }
}