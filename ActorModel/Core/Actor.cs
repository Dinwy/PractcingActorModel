using System;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
{
    public abstract class Actor : IActor
    {
        public Guid InstanceId { get; } = Guid.NewGuid();
        public ActorFactory ActorFactory { get; private set; }

        public Actor(ActorFactory af)
        {
            ActorFactory = af;
            af.Register(this);
        }

        public virtual async Task SendMessage(IActor t, IMessage m)
        {
            await t.GetMessage(this, m);
        }

        public virtual async Task GetMessage(IActor s, IMessage m)
        {
            await Task.CompletedTask;
        }
    }
}