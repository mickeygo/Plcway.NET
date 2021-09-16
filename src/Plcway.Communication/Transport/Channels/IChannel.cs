using System.Threading.Tasks;

namespace Plcway.Communication.Transport.Channels
{
    public interface IChannel
    {
        Task RunAsync();
    }
}
