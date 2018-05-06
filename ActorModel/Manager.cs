using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayGround
{
    public class Manager : IActor
    {
        public Guid InstanceId { get; } = Guid.NewGuid();
        public Queue<IMessage> MailBox = new Queue<IMessage>();
        public ActorFactory ActorFactory { get; private set; }

        public Manager(ActorFactory af)
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

            await Task.CompletedTask;
        }
    }
}