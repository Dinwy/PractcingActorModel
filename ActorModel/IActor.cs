using System;
using System.Threading.Tasks;

namespace PlayGround
{
    public interface IActor
    {
        Guid InstanceId { get; }
        Task SendMessage(IActor t, IMessage m);
        Task GetMessage(IActor s, IMessage m);
    }

    public interface IMessage { }
}