using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
{
    public class Manager : Actor
    {
        public Manager() : base() { }

        public override async Task GetMessage(IActor s, IMessage m)
        {
            await Task.CompletedTask;
        }
    }
}