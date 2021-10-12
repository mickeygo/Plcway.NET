using System.Threading.Tasks;

namespace Plcway.Framework.Transport.Channels
{
    public interface IChannel
    {
        Task RunAsync();
    }
}
