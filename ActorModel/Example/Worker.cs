using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
{
    public class Worker : Actor
    {
        private Guid ManagerID { get; set; }
        public Counter Counter { get; private set; } = new Counter(0);

        public Worker() : base() { }

        public Task SetManager(Guid guid)
        {
            ManagerID = guid;
            return Task.CompletedTask;
        }

        public override async Task GetMessage(IActor s, IMessage m)
        {
            await base.GetMessage(s, m);
            await ProcessMessage();
        }

        public async Task ProcessMessage()
        {
            await IncreaseCounter();
        }

        private async Task IncreaseCounter()
        {
            IMessage data;
            if (!MailBox.TryDequeue(out data))
            {
                await Task.Delay(5);
                await ProcessMessage();
                return;
            }

            Interlocked.Add(ref Counter.Count, (data as IncreaseCount).Amount);
            await Task.CompletedTask;
        }
    }
}