using System;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
{
    public class CountAddMessage : IMessage
    {
        public Counter Counter;

        public CountAddMessage()
        {
            Counter = new Counter(0);
        }
    }
}