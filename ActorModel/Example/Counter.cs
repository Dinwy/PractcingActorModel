using System;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
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