using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayGround
{
    public class ActorFactory
    {
        public Dictionary<Guid, IActor> Actors = new Dictionary<Guid, IActor>();

        public IActor GetActor(Guid guid)
        {
            return Actors[guid];
        }

        public void Register(IActor actor)
        {
            Actors.Add(actor.InstanceId, actor);
        }
    }
}