using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    enum NetSrc
    {
        NS_CLIENT,
        NS_SERVER,
        NS_MULTICAST
    }

    enum NetAdrType
    {
        NA_UNUSED = 0,
        NA_LOOPBACK,
        NA_BROADCAST,
        NA_IP
    }

    struct NetIp
    {
        public byte b1;
        public byte b2;
        public byte b3;
        public byte b4;
    }

    struct NetAdr
    {
        public NetAdrType adrType;
        public NetIp ip;
        public UInt16 port;
    }
}
