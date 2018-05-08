using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
{
    public class Worker : Actor
    {
        public Counter Counter { get; private set; } = new Counter(0);

        public Worker() : base() { }

        public override async Task GetMessage(IActor s, IMessage m)
        {
            await base.GetMessage(s, m);
            await CheckMailBox();
        }

        public Task CheckMailBox()
        {
            if (MailBox.Count == 0) return Task.CompletedTask;
            IMessage data;

            if (!MailBox.TryDequeue(out data))
            {
                return Task.CompletedTask;
            }

            if (data is IncreaseCount)
            {
                IncreaseCounter(data as IncreaseCount);
            }

            return Task.CompletedTask;
        }

        private Task IncreaseCounter(IncreaseCount data)
        {
            // Interlocked.Add(ref Counter.Count, data.Amount);
            Counter.Count += data.Amount;
            Task.Run(async () => await CheckMailBox());
            return Task.CompletedTask;
        }
    }
}