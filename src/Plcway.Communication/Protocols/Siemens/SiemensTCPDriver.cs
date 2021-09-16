using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plcway.Communication.Protocols.Siemens
{
    /// <summary>
    /// S7 TCP 协议
    /// </summary>
    public sealed class SiemensTCPDriver
    {
        libnodave.daveOSserialType fds;
        libnodave.daveInterface di;
        internal libnodave.daveConnection dc;
        int _rack;
        int _slot;
        string _IP;
        object _async = new object();
        DateTime _closeTime = DateTime.Now;

        public SiemensTCPDriver()
        {

        }

        public bool Connect()
        {
            lock (_async)
            {
                if (!_closed) return true;
                double sec = (DateTime.Now - _closeTime).TotalMilliseconds;
                if (sec < 6000)
                    System.Threading.Thread.Sleep(6000 - (int)sec);
                fds.rfd = libnodave.openSocket(102, _IP);
                fds.wfd = fds.rfd;
                if (fds.rfd > 0)
                {
                    di = new libnodave.daveInterface(fds, "IF1", 0, libnodave.daveProtoISOTCP, libnodave.daveSpeed187k);
                    di.setTimeout(TimeOut);
                    //	    res=di.initAdapter();	// does nothing in ISO_TCP. But call it to keep your programs indpendent of protocols
                    //	    if(res==0) {
                    dc = new libnodave.daveConnection(di, 0, _rack, _slot);
                    if (0 == dc.connectPLC())
                    {
                        _closed = false;
                        return true;
                    }
                }
                if (dc != null) dc.disconnectPLC();
                libnodave.closeSocket(fds.rfd);
            }
            _closed = true;
            return false;
        }

        public void Dispose()
        {
            lock (_async)
            {
                if (dc != null) dc.disconnectPLC();
                libnodave.closeSocket(102);
                foreach (IGroup grp in _groups)
                {
                    grp.Dispose();
                }
                _closed = true;
            }
        }
    }
}
