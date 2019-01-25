using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HLDS.NET
{
    static class Sys
    {
        public static void Init() // done
        {
            HLDS.HostInit = false;

            InitArgs();

            if (COM.CheckParam("-dev") > 0)
            {
                HLDS.developer.data = "1";
                HLDS.developer.value = 1;
            }

            InitClock();
            CheckOSVersion();
            SetStartTime();

            Memory.Init();
            FileSystem.Init();
            Host.Init();

            if (HLDS.HostInit)
            {
                NET.Config(true);
                Host.InitializeGameDLL();
            }
        }

        public static void InitClock()
        {
            //
        }

        public static void Error(string text) // done
        {
            MessageBox.Show("FATAL ERROR (shutting down): " + text, "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        public static void CheckOSVersion() // skip
        {
            //
        }

        public static void SetStartTime()
        {
            //
        }

        public static void Shutdown() // done
        {
            Host.Shutdown();
            FileSystem.Shutdown();
            Memory.Shutdown();
            ShutdownClock();
            ShutdownArgs();
        }

        public static void InitArgs()
        {
            //
        }

        public static void ShutdownClock()
        {
            //
        }

        public static void ShutdownArgs()
        {
            //
        }

        public static void Sleep(int ms)
        {
            Thread.Sleep(ms);
        }

        public static void DebugOutStraight(string text)
        {
            Console.WriteLine(text);
        }
    }
}
