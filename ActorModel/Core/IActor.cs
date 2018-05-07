using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Dinwy.Utils.ActorModel
{
    public interface IActor
    {
        ConcurrentQueue<IMessage> MailBox { get; }
        Guid InstanceId { get; }
        Task SendMessage(IActor t, IMessage m);
        Task GetMessage(IActor s, IMessage m);
    }

    public interface IMessage { }
}