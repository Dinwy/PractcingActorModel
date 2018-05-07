using System;
using System.Collections.Generic;
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
            var data = m as IncreaseCount;
            Counter.Count += data.Amount;
            await Task.CompletedTask;
        }

        public Task ProcessMessage()
        {
            var data = MailBox.Dequeue();

            Counter.Count += (data as IncreaseCount).Amount;
            return Task.CompletedTask;
        }

        public async Task Increment(IMessage m)
        {
            Counter.Count += (m as IncreaseCount).Amount;
            await Task.CompletedTask;
        }
    }
}