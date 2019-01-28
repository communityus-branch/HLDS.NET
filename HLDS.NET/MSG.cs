using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    static class MSG
    {
        public static void WriteChar(ref SizeBuf Buffer, char value) { }
        public static void WriteByte(ref SizeBuf Buffer, byte value) { }
        public static void WriteShort(ref SizeBuf Buffer, Int16 value) { }
        public static void WriteWord(ref SizeBuf Buffer, UInt16 value) { }
        public static void WriteLong(ref SizeBuf Buffer, Int32 value) { }
        public static void WriteFloat(ref SizeBuf Buffer, float Value) { }
        public static void WriteString(ref SizeBuf Buffer, string S) { }
        // public static void WriteBuffer(ref SizeBuf Buffer; Size: UInt; Data: Pointer);
        public static void WriteAngle(ref SizeBuf Buffer, float F) { }
        public static void WriteHiResAngle(ref SizeBuf Buffer, float F) { }
        public static void WriteOneBit(byte B) { }
        public static void StartBitWriting(ref SizeBuf Buffer) { }
        public static bool IsBitWriting() { return false; }
        public static void EndBitWriting() { }
        public static void WriteBits(UInt32 B, uint Count) { }
        public static void WriteSBits(Int32 B, uint Count) { }
        public static void WriteBitString(string S) { }
        // public static void WriteBitData(Buffer: Pointer; Size: UInt);
        public static void WriteBitAngle(float F, uint Count) { }
        public static float ReadBitAngle(uint Count) { return 0.0f; }
        public static uint CurrentBit() { return 0; }
        public static bool IsBitReading() { return false; }
        public static void StartBitReading(ref SizeBuf Buffer) { }
        public static void EndBitReading(ref SizeBuf Buffer) { }
        public static Int32 ReadOneBit() { return 0; }
        public static UInt32 ReadBits(uint Count) { return 0; }
        public static UInt32 PeekBits(uint Count) { return 0; }
        public static Int32 ReadSBits(uint Count) { return 0; }
        public static string ReadBitString() { return ""; }
        // public static void ReadBitData(Buffer: Pointer; Size: UInt);
        public static float ReadBitCoord() { return 0.0f; }
        public static void WriteBitCoord(float F) { }
        // public static void ReadBitVec3Coord(out Vec3 P) P = a; }
        public static void WriteBitVec3Coord(Vec3 P) { }
        public static float ReadCoord() { return 0.0f; }
        public static void WriteCoord(ref SizeBuf Buffer, float F) { }
       // public static void ReadVec3Coord(ref SizeBuf Buffer; out P: TVec3);
        public static void WriteVec3Coord(ref SizeBuf Buffer, Vec3 P) { }
        public static void BeginReading() { }
        public static char ReadChar() { return 'a'; }
        public static byte ReadByte() { return 0; }
        public static Int16 ReadShort() { return 0; }
        public static UInt16 ReadWord() { return 0; }
        public static Int32 ReadLong() { return 0; }
        public static float ReadFloat() { return 0.0f; }
       // public static Int32 ReadBuffer(Size: UInt; Buffer: Pointer): Int32;
        public static string ReadString() { return ""; }
        public static string ReadStringLine() { return ""; }
        public static float ReadAngle() { return 0.0f; }
        public static float ReadHiResAngle() { return 0.0f; }
        public static void ReadUserCmd(ref UserCmd Dest, UserCmd Source) { }

    }
}
