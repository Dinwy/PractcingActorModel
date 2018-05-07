using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
{
    public abstract class Actor : IActor
    {
        public Guid InstanceId { get; } = Guid.NewGuid();
        public ConcurrentQueue<IMessage> MailBox { get; } = new ConcurrentQueue<IMessage>();

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