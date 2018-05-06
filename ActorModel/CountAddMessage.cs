using System;
using System.Threading.Tasks;

namespace PlayGround
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