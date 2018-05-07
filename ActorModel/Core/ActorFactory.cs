using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
{
    public class ActorFactory
    {
        public Dictionary<Guid, IActor> Actors = new Dictionary<Guid, IActor>();

        public IActor GetActor<T>(Guid guid) where T : Actor, new()
        {
            if (Actors.ContainsKey(guid))
            {
                return Actors[guid];
            }
            else
            {
                var actor = new T();
                try
                {
                    Actors.Add(actor.InstanceId, actor);
                }
                catch (Exception e) when (e is ArgumentException)
                {
                    throw e;
                }

                return actor;
            }
        }

        public void Register(IActor actor)
        {
            Actors.Add(actor.InstanceId, actor);
        }
    }
}