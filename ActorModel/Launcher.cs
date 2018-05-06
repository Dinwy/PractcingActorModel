using System;
using System.Threading.Tasks;

namespace PlayGround
{
    public class Launcher
    {
        public Launcher() { }

        public void Run()
        {
            var actorFactory = new ActorFactory();
            var p1 = new Worker(actorFactory);
            var p2 = new Worker(actorFactory);
            var p3 = new Worker(actorFactory);
            var m = new Manager(actorFactory);

            var data = new Counter(0);

            for (int j = 0; j < 1000; j++)
            {
                Task.Run(() => m.SendMessage(p1, data));
                Task.Run(() => m.SendMessage(p2, data));
                Task.Run(() => m.SendMessage(p3, data));
                Task.Run(() => m.SendMessage(p1, data));
                Task.Run(() => m.SendMessage(p2, data));
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