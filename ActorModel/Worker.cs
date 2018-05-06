using System;
using System.Threading.Tasks;

namespace PlayGround
{
    public class Worker : IActor
    {
        public Guid InstanceId { get; } = Guid.NewGuid();
        public ActorFactory ActorFactory { get; private set; }

        public Worker(ActorFactory af)
        {
            ActorFactory = af;
            af.Register(this);
        }

        public async Task SendMessage(IActor t, IMessage m)
        {
            await t.GetMessage(this, m);
        }

        public async Task GetMessage(IActor s, IMessage m)
        {
            var data = m as Counter;
            System.Console.WriteLine($"{InstanceId} Jobs done: {data.Count}");
            data.Count++;
            var manager = ActorFactory.GetActor(s.InstanceId);
            await SendMessage(manager, data as IMessage);
        }
    }
}