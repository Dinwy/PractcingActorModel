using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
{
    public class ActorFactory
    {
        public Dictionary<Guid, IActor> Actors = new Dictionary<Guid, IActor>();

        public IActor GetActor<T>(Guid guid) where T : Actor
        {
            if (Actors.ContainsKey(guid))
            {
                return Actors[guid];
            }
            else
            {
                var actor = (T)Activator.CreateInstance(typeof(T), this);
                Actors.Add(actor.InstanceId, actor);
                return actor;
            }
        }

        public void Register(IActor actor)
        {
            Actors.Add(actor.InstanceId, actor);
        }
    }
}