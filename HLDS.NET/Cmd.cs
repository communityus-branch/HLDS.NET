using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    class Cmd
    {
        public static Cmd temp_cmd = new Cmd();

        public static void Init() { }
        public static void Shutdown() { }

        public static uint Argc()
        {
            return 0;
        }

        public static string Argv(uint index)
        {
            return "";
        }

        public static string Args()
        {
            return "";
        }

        public static void TokenizeString(string data) { }

        public static ref Cmd FindCmd(string name)
        {
            return ref temp_cmd;
        }

        public static ref Cmd FindPrevCmd(string name)
        {
            return ref temp_cmd;
        }

        //public static void AddCommand(string name, Func: TCmdFunction);
        //public static void AddMAllocCommand(string name; Func: TCmdFunction; Flags: TCmdFlags);
        //public static void AddHUDCommand(Name: PLChar; Func: TCmdFunction);
        //public static void AddGameCommand(Name: PLChar; Func: TCmdFunction);
        //public static void AddWrapperCommand(Name: PLChar; Func: TCmdFunction);
        public static void RemoveHUDCmds() { }
        public static void RemoveGameCmds() { }
        public static void RemoveWrapperCmds() { }

        public static bool Exists(string name)
        {
            return false;
        }
        //public static void ExecuteString(string text; Source: TCmdSource);
        public static uint CheckParm(string name)
        {
            return 0;
        }
    }
}
