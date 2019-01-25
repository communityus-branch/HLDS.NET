using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    class CVar
    {
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


        public static void DirectSet(CVar cvar, string _value) // TODO
        {
            cvar.data = _value;
            float.TryParse(_value, out cvar.value);
        }
    }
}
