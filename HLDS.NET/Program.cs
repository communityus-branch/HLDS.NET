using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    class HLDS
    {
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
            if (!Global.ShutdownCalled)
            {
                Global.ShutdownCalled = true;
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
