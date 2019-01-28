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
        public NetSrc Source; // +0, fully confirmed: 0, 1, 2 are possible values
        public NetAdr Addr; // +4, fully confirmed
        public UInt32 ClientIndex; // +24, fully confirmed client index
        public float LastReceived;
        public float FirstReceived; // +28 and +32

        public double Rate; // +40 | +36, guess it's confirmed
        public double ClearTime; // +48 | +44 fully confirmed

        public Int32 IncomingSequence; // +56 confirmed fully (2nd step)
        public Int32 IncomingAcknowledged; // +60 confirmed fully
        public Int32 IncomingReliableAcknowledged; // +64 confirmed fully
        public Int32 IncomingReliableSequence; // +68 confirmed fully (2nd step)

        public Int32 OutgoingSequence; // W 72   L 68 confirmed fully (2nd step)
        public Int32 ReliableSequence; // W 76 L 72  confirmed fully
        public Int32 LastReliableSequence; // W 80 L 76 confirmed fully

        //Client: Pointer; // +84 | +80, confirmed  pclient
       // FragmentFunc: function(Client: Pointer) : UInt32; cdecl; // +88 | +84, fully confirmed
        SizeBuf NetMessage; // +92 | +88, fully confirmed
        //   NetMessageBuf: array[1..MAX_NETCHANLEN] of Byte; // W 112,  L 108 fully confirmed

        public UInt32 ReliableLength; // +4104 yeah confirmed
                                      //  ReliableBuf: array[1..MAX_NETCHANLEN] of Byte; // W 4108 confirmed   L 4104 confirmed

        // this fragbuf stuff seems to be confirmed
        //    FragBufQueue: array[TNetStream] of PFragBufDir; // W 8100   L 8096?
        //    FragBufActive: array[TNetStream] of Boolean; // W 8108
        //    FragBufSequence: array[TNetStream] of Int32; // W 8116
        //    FragBufBase: array[TNetStream] of PFragBuf; // W 8124   L ?8120
        //    FragBufNum: array[TNetStream] of UInt32; // W 8132 L 8128
        //    FragBufOffset: array[TNetStream] of UInt16; // W 8140
        //    FragBufSize: array[TNetStream] of UInt16; // W 8144

        //  IncomingBuf: array[TNetStream] of PFragBuf; // W 8148 L 8144
        //  IncomingReady: array[TNetStream] of Boolean; // W 8156 L 8152  is completed

        public string FileName;
     
     //   TempBuffer: Pointer; // W 8424
     //   TempBufferSize: UInt32; // W 8428

     //   Flow: array[TFlowSrc] of TNetchanFlowData; // W 8432    flow data size = 536

















        










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
