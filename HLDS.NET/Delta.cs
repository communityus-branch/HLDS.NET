using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    class Delta
    {
        public struct Field
        {

        }

        public static Delta temp_delta = new Delta();
        public static Field temp_delta_field = new Field();

        public static ref Field FindField(Delta d, string name)
        {
            return ref temp_delta_field;
        }

        public static int FindFieldIndex(Delta d, string name)
        {
            return 0;
        }

        public static void SetField(ref Delta d, string name) { }
        public static void UnsetField(ref Delta d, string name) { }
        public static void SetFieldByIndex(ref Delta d, uint index) { }
        public static void UnsetFieldByIndex(ref Delta d, uint index) { }
        public static void ClearFlags(ref Delta d) { }
        // public static uint TestDelta(OS, NS: Pointer; var Delta: TDelta): UInt;
        public static uint CountSendFields(ref Delta d)
        {
            return 0;
        }

       // public static void MarkSendFields(OS, NS: Pointer; var Delta: TDelta);
       // public static void WriteMarkedFields(OS, NS: Pointer; const Delta: TDelta);
       // public static uint CheckDelta(OS, NS: Pointer; var Delta: TDelta): UInt;
       // public static void WriteMarkedDelta(OS, NS: Pointer; ForceUpdate: Boolean; var Delta: TDelta; Fields: UInt; Func: TProcedure);
       // public static void WriteDelta(OS, NS: Pointer; ForceUpdate: Boolean; var Delta: TDelta; Func: TProcedure);
       // public static int ParseDelta(OS, NS: Pointer; var Delta: TDelta): Int;
        public static void FreeDescription(ref Delta d) { }

    //    public static void AddEncoder(string name; Func: TDeltaEncoder);
        // function Delta_LookupEncoder(Name: PLChar): TDeltaEncoder;
        public static void InitEncoders() { }

        public static bool Load(string name, ref Delta delta, string fileName)
        {
            return false;
        }

        public static ref Delta Register(string name, string fileName)
        {
            return ref temp_delta;
        }

        public static void ClearRegistrations() { }

        public static void Init() { }
        public static void Shutdown() { }
    }
}
