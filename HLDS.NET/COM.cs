using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    static class COM
    {
        public static int ArgCount = 0;
        public static string[] ArgList;

        // SysArgs.pas

        public static uint CheckParm(string name)
        {
            return 0;
        }

        public static string ParmByIndex(uint index)
        {
            return "";
        }

        public static string ParmValueByIndex(uint index)
        {
            return "";
        }

        public static string ParmValueByName(string name)
        {
            return "";
        }

        public static uint GetParmCount()
        {
            return 0;
        }

        public static string GetLocalDir()
        {
            return "";
        }

        public static bool ParmInBounds(uint index)
        {
            return false;
        }
    }
}
