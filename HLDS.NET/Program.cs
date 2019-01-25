using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    class HLDS
    {
        public static bool ShutdownCalled = false;
        public static bool HostInit = false;
        public static double RealTime = 0.0;
        public static bool InHostShutdown = false;

        public static CVar developer = new CVar("developer", "0");
        public static CVar sv_version = new CVar("sv_version", "", CVar.Flags.FCVAR_SERVER);

        static void Start()
        {
            Sys.Init();
        }

        static bool Frame()
        {
            return Host.Frame();
        }

        static void Shutdown()
        {
            if (!ShutdownCalled)
            {
                ShutdownCalled = true;
                Sys.Shutdown();
            }
        }

        static void Main(string[] args)
        {
            Start();

            while (Frame())
            {
                Sys.Sleep(0);
            }

            Shutdown();
        }
    }
}
