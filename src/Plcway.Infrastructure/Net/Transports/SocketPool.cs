using System.Net.Sockets;

namespace Plcway.Infrastructure.Net.Transports
{
    /// <summary>
    /// Socket 连接池
    /// </summary>
    public class SocketPool
    {
        public SocketPool()
        {
            
        }

        public Socket? Get()
        {
            return default;
        }

        public void Push()
        {

        }
    }

    internal class SocketEntry
    {
        public Socket Socket { get; set; }

        public int Status { get; set; }

        public long Version { get; set; }
    }
}
