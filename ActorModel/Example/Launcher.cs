using System;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
{
    public class Launcher
    {
        public Launcher() { }

        public void Run()
        {
            var actorFactory = new ActorFactory();
            var m = actorFactory.GetActor<Manager>(new Guid());
            var w1 = actorFactory.GetActor<Worker>(new Guid()) as Worker;
            var w2 = actorFactory.GetActor<Worker>(new Guid()) as Worker;
            w1.SetManager(m.InstanceId);
            w2.SetManager(m.InstanceId);

            var data = new Counter(0);
            for (int j = 0; j < 1000; j++)
            {
                Task.Run(() => m.SendMessage(w1, msg));
                Task.Run(() => m.SendMessage(w2, msg));
                Task.Run(() => m.SendMessage(w1, msg));
                Task.Run(() => m.SendMessage(w2, msg));
            }

            Console.ReadLine();
            System.Console.WriteLine(w1.Counter.Count);
            System.Console.WriteLine(w2.Counter.Count);
            Console.ReadLine();
            System.Console.WriteLine(w1.Counter.Count);
            System.Console.WriteLine(w2.Counter.Count);
            Console.ReadLine();
            System.Console.WriteLine(w1.Counter.Count);
            System.Console.WriteLine(w2.Counter.Count);

            Console.ReadLine();
        }
    }
}
