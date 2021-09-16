using System.Diagnostics.Contracts;
using System.Net.Sockets;
using Microsoft.Extensions.ObjectPool;

namespace Plcway.Infrastructure.Net.Transports
{
    /// <summary>
    /// Socket 连接池
    /// </summary>
    public class SocketPool
    {
        public const int MaxSize = 64;

        private readonly ObjectPool<Socket> _objectPool;

        public static SocketPool Default => new();

        public SocketPool()
        {
            var policy = new SocketPooledObjectPolicy();
            _objectPool = new DefaultObjectPool<Socket>(policy, MaxSize);
        }

        public Socket Get()
        {
            return _objectPool.Get();
        }

        public void Push(Socket socket)
        {
            Contract.Requires(socket != null);
            _objectPool.Return(socket);
        }
    }

    public class SocketPooledObjectPolicy : PooledObjectPolicy<Socket>
    {
        public override Socket Create()
        {

            throw new System.NotImplementedException();
        }

        public override bool Return(Socket obj)
        {
            return true;
        }
    }
}
