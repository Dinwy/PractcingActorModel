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

            var msg = new IncreaseCount(2);

            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10000; j++)
                    {
                        Task.Run(() => m.SendMessage(w1, msg));
                        Task.Run(() => m.SendMessage(w2, msg));
                        Task.Run(() => m.SendMessage(w1, msg));
                        Task.Run(() => m.SendMessage(w2, msg));
                    }
                }
            });

            while (true)
            {
                Console.ReadLine();
                System.Console.WriteLine($"w1 Counter : {w1.Counter.Count}");
                System.Console.WriteLine($"w2 Counter : {w2.Counter.Count}");
                System.Console.WriteLine($"w1 MailBox : {w1.MailBox.Count}");
                System.Console.WriteLine($"w2 MailBox : {w2.MailBox.Count}");
            }
        }
    }
}
