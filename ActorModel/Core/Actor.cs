using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
{
    public abstract class Actor : IActor
    {
        public Guid InstanceId { get; } = Guid.NewGuid();
        public ActorFactory ActorFactory { get; private set; }
        public Queue<IMessage> MailBox = new Queue<IMessage>();

        public Actor() { }

        public virtual async Task SendMessage(IActor t, IMessage m)
        {
            await t.GetMessage(this, m);
        }

        public virtual async Task GetMessage(IActor s, IMessage m)
        {
            MailBox.Enqueue(m);
            await Task.CompletedTask;
        }
    }
}