using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
{
    public class Manager : Actor
    {
        public Queue<IMessage> MailBox = new Queue<IMessage>();

        public Manager(ActorFactory af) : base(af) { }

        public override async Task GetMessage(IActor s, IMessage m)
        {
            var data = m as Counter;

            await Task.CompletedTask;
        }
    }
}