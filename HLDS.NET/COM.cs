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

        public static int CheckParam(string name)
        {
            for (int i = 1; i < ArgCount; i++)
            {
                if (name == ArgList[i])
                    return i;
            }
            return 0;
        }
    }
}
