using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    class Netchan
    {





        public static void OutOfBandPrint(NetSrc source, NetAdr addr, string s) { }
        

        public static void FragSend(ref Netchan c) { }
       // public static void AddBufferToList(var Base: PFragBuf; P: PFragBuf);

        public static void Clear(ref Netchan c) { }

      //  public static void CreateFragments(ref Netchan c; var SB: TSizeBuf) { }
      //  public static void CreateFileFragmentsFromBuffer(ref Netchan c; Name: PLChar; Buffer: Pointer; Size: UInt) { }

        public static bool CreateFileFragments(ref Netchan c, string name)
        {
            return false;
        }

      //  public static void FlushIncoming(ref Netchan c; Stream: TNetStream);

       // public static void Setup(NetSrc source, ref Netchan c, NetAdr addr, int ClientID; ClientPtr: PClient; Func: TFragmentSizeFunc);

        public static bool Process(ref Netchan c)
        {
            return false;
        }

       // public static void Transmit(ref Netchan c, uint Size; Buffer: Pointer);

        public static bool IncomingReady(Netchan c)
        {
            return false;
        }

        public static bool CopyNormalFragments(ref Netchan c)
        {
            return false;
        }

        public static bool CopyFileFragments(ref Netchan c)
        {
            return false;
        }

        public static bool CanPacket(ref Netchan c)
        {
            return false;
        }

        public static void Init()
        {
            //
        }
    }
}
