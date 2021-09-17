﻿using System.Net;

namespace Plcway.Communication.Protocols
{
    /// <summary>
    /// 以太网形式
    /// </summary>
    public interface IEthernetClient : IIoTClient
    {
        /// <summary>
        /// IPEndPoint
        /// </summary>
        IPEndPoint IpEndPoint { get; }
    }
}