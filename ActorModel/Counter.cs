using System;
using System.Threading.Tasks;

namespace PlayGround
{
    public class Counter : IMessage
    {
        public int Count;

        public Counter(int count)
        {
            Count = count;
        }
    }
}