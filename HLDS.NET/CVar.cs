using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    class CVar
    {
        public static CVar temp_cvar = new CVar();

        public enum Flags
        {
            FCVAR_ARCHIVE = 0,
            FCVAR_USERINFO,
            FCVAR_SERVER,
            FCVAR_EXTDLL,
            FCVAR_CLIENTDLL,
            FCVAR_PROTECTED,
            FCVAR_SPONLY,
            FCVAR_PRINTABLEONLY,
            FCVAR_UNLOGGED,
            __FCVAR_PADDING = 31
        }

        public CVar(string _name = "", string _data = "", Flags _flags = Flags.FCVAR_ARCHIVE)
        {
            name = _name;
            data = _data;
            flags = _flags;
        }

        public string name;
        public string data;
        public Flags flags;
        public float value;

        // statics

        public static void Init()
        {
            //Cmd.AddCommand("cvarlist", asdasd); // TODO
        }

        public static void Shutdown()
        {
            //
        }

        public static ref CVar FindVar(string name)
        {
            return ref temp_cvar;
        }

        public static ref CVar FindPrevVar(string name)
        {
            return ref temp_cvar;
        }
        
        public static float VariableValue(string name)
        {
            return 0.0f;
        }

        public static int VariableInt(string name)
        {
            return 0;
        }

        public static string VariableString(string name)
        {
            return "";
        }

        public static void DirectSet(ref CVar cvar, string value)
        {
            //
        }

        public static void Set(string name, string value)
        {
            //
        }

        public static void SetValue(string name, float value)
        {
            //
        }

        public static void RegisterVariable(ref CVar cvar)
        {
            //
        }

        public static void RemoveHUDCVars()
        {
            //
        }
        
        public static string IsMultipleTokens(string name)
        {
            return "";
        }

        public static bool Command()
        {
            return false;
        }
        
        //public static void WriteVariables(F: TFile);
        //public static void Cmd_CVarList; cdecl;
        
        public static uint CountServerVariables()
        {
            return 0;
        }

        public static void UnlinkExternals()
        {
            //
        }
    }
}
