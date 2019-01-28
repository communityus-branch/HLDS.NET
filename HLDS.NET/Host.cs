using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    static class Host
    {
        public static string SaveGameDirectory()
        {
            return "";
        }

        public static void ClearSaveDirectory() { }

        public static bool IsSinglePlayerGame()
        {
            return false;
        }

        public static void ClearGameState() { }

        public static void Map(string name, bool save) { }

        public static void Say(bool team) { }

        public static void EndSection(string name) { }

        public static void ClearMemory() { }

        public static void Error(string msg) { }

        public static void ShutdownServer(bool SkipNotify) { }



        public static bool Frame()
        {
            SetHostTimes();

            bool result = false;
            int TimeStart = 0;
            int TimeEnd = 0;
            int Count = 0;
            bool profile = false;

            if (Global.QuitCommandIssued)
                result = false;
            else
            {
                profile = Global.host_profile.value != 0;
                if (!profile)
                {
                    Host._Frame(Global.HostTimes.Frame);
                    if (Global.HostStateInfo != 0)
                    {
                        Global.HostStateInfo = 0;
                        CBuf.Execute();
                    }
                }
                else
                {
                    TimeStart = Sys.FloatTime();
                    Host._Frame(Global.HostTimes.Frame);
                    TimeEnd = Sys.FloatTime();

                    if (Global.HostStateInfo != 0)
                    {
                        Global.HostStateInfo = 0;
                        CBuf.Execute();
                    }

                    Global.TimeCount += 1;
                    Global.TimeTotal = Global.TimeTotal + TimeEnd - TimeStart;

                    if (Global.TimeCount >= 1000)
                    {
                        Count = 0;
                        for (int i = 0; i < SVS.MaxClients; i++)
                        {
                            if (SVS.Clients[i].Active)
                                Count += 1;
                        }

                        Print("host_profile: bla bla bla"); // TODO

                        Global.TimeTotal = 0;
                        Global.TimeCount = 0;
                    }
                }
            }

            result = true;

            return result;
        }

        private static bool FilterTime(double time)
        {
            return false;
        }

        private static void ComputeFPS(double a)
        {

        }

        private static void WriteSpeeds()
        {
            
        }

        private static void UpdateStats()
        {

        }

        public static void _Frame(double time)
        {
            if (Host.FilterTime(time))
            {
                Host.ComputeFPS(Global.HostFrameTime);
                CBuf.Execute();
                if (Global.HostTimes.CollectData)
                    Global.HostTimes.Host = Sys.FloatTime();

                SV.Frame();
                if (Global.HostTimes.CollectData)
                    Global.HostTimes.SV = Sys.FloatTime();

                SV.CheckForRcon();
                if (Global.HostTimes.CollectData)
                    Global.HostTimes.Rcon = Sys.FloatTime();

                Host.WriteSpeeds();
                Global.HostNumFrames++;
                if (Global.sv_stats.value != 0)
                    Host.UpdateStats();

                if (Global.host_killtime.value != 0 && Global.host_killtime.value < Global.SV.Time)
                    CBuf.AddText("quit\n");

               // UI_Frame(RealTime);
            }
        }

        public static void Init()
        {
            Global.RealTime = 0.0;

            Trash.Rand_Init();
            CBuf.Init();
            Cmd.Init();
            CVar.Init();
            InitLocal();
            ClearSaveDirectory();
            Con.Init();
            HPAK.Init();

            SV.SetMaxClients();
            W.LoadWADFile();
            Decal.Init();
            Mod.Init();
            R.Init();
            NET.Init();
            Netchan.Init();
            Delta.Init();
            SV.Init();

            string buf = "asdasd"; // TODO
            CVar.DirectSet(ref Global.sv_version, buf);

            HPAK.CheckIntegrity("custom.hpk");
            CBuf.InsertText("exec valve.rc\n");
            Hunk.AllocName(0, "-HOST_HUNKLEVEL-");
            Global.HostHunkLevel = Hunk.LowMark;

            Global.HostActive = 1;
            Global.HostNumFrames = 0;

            Global.HostTimes.Prev = Sys.FloatTime();
            Global.HostInit = true;
        }

        public static void InitializeGameDLL()
        {
            //
        }

        public static void Shutdown()
        {
            if (Global.InHostShutdown)
                Sys.DebugOutStraight("Host_Shutdown: Recursive shutdown.");
            else
            {
                Global.InHostShutdown = true;
                Global.HostInit = false;

                SV.ServerDeactivate();

                Mod.ClearAll();
                SV.ClearAllEntities();
                CM.FreePAS();
                SV.FreePMSimulator();

                SV.Shutdown();
                ReleaseEntityDLLs();
                Delta.Shutdown();
                NET.Shutdown();

                // if WADPath != nil then 
                //  Mem.FreeAndNil(WADPath);

                Draw.DecalShutdown();
                W.Shutdown();
                HPAK.FlushHostQueue();
                Con.Shutdown();
                Cmd.RemoveGameCmds();
                Cmd.Shutdown();
                CVar.Shutdown();

                LPrint("Server shutdown\n");
                Log.Close();
                Global.RealTime = 0.0;
                SV.Time = 0.0;
            }
        }

    }
}
