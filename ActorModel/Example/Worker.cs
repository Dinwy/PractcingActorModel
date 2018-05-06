using System;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
{
    public class Worker : Actor
    {
        public Worker(ActorFactory af) : base(af) { }

        public override async Task GetMessage(IActor s, IMessage m)
        {
            var data = m as Counter;
            System.Console.WriteLine($"{InstanceId} Jobs done: {data.Count}");
            data.Count++;
            var manager = ActorFactory.GetActor<Worker>(s.InstanceId);
            await SendMessage(manager, data as IMessage);
        }
    }
}