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
            var p1 = actorFactory.GetActor<Worker>(new Guid());
            var m = actorFactory.GetActor<Manager>(new Guid());

            var data = new Counter(0);

            for (int j = 0; j < 1000; j++)
            {
                Task.Run(() => m.SendMessage(p1, data));
                Task.Run(() => m.SendMessage(p1, data));
            }

            Console.ReadLine();
            System.Console.WriteLine(data.Count);
            Console.ReadLine();
            System.Console.WriteLine(data.Count);
            Console.ReadLine();
            System.Console.WriteLine(data.Count);
            Console.ReadLine();
        }
    }
}