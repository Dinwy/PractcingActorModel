using System;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
{
    public class IncreaseCount : IMessage
    {
        public int Amount { get; private set; }

        public IncreaseCount(int amount)
        {
            Amount = amount;
        }
    }
}