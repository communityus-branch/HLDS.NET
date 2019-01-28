using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    static class NET
    {
    //    public static string AdrToString(const NetAdr a, out Buf; L: UInt): PLChar; overload;
    //    public static string BaseAdrToString(const A: TNetAdr; out Buf; L: UInt): PLChar;
        public static bool CompareBaseAdr(NetAdr a1, NetAdr a2)
        {
            return false;
        }

        public static bool CompareAdr(NetAdr a1, NetAdr a2)
        {
            return false;
        }

       // public static bool StringToAdr(string s; out A: TNetAdr): Boolean;
      //  public static bool StringToSockaddr(Name: PLChar; out S: TSockAddr): Boolean;
        public static bool CompareClassBAdr(NetAdr a1, NetAdr a2)
        {
            return false;
        }

        public static bool IsReservedAdr(NetAdr a)
        {
            return false;
        }

        public static bool IsLocalAddress(NetAdr a)
        {
            return false;
        }

        public static void Config(bool EnableNetworking)
        {
            //
        }

        //public static void SendPacket(NetSrc source, uint size; Buffer: Pointer; NetAdr dest);

        public static void ThreadLock() { }
        public static void ThreadUnlock() { }

        //   function NET_AllocMsg(Size: UInt): PNetQueue;

        public static bool GetPacket(NetSrc source)
        {
            return false;
        }
            
        public static void ClearLagData(bool client, bool server) { }

        public static void Init() { }
        public static void Shutdown() { }
    }
}
