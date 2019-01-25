using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    static class Host
    {
        
        public static void Init()
        {
            HLDS.RealTime = 0.0;
        }

        public static void InitializeGameDLL()
        {
            Rand.Init();
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
            CVar.DirectSet(HLDS.sv_version, buf);

            HPAK.CheckIntegrity("custom.hpk");
            CBuf.InsertText("exec valve.rc\n");
            Hunk.AllocName(0, "-HOST_HUNKLEVEL-");
            HostHunkLevel = Hunk.LowMark;

            Active = 1;
            NumFrames = 0;

            Times.Prev = Sys.FloatTime();
            HLDS.HostInit = true;
        }

        public static void Shutdown()
        {
            if (HLDS.InHostShutdown)
                Sys.DebugOutStraight("Host_Shutdown: Recursive shutdown.");
            else
            {
                HLDS.InHostShutdown = true;
                HLDS.HostInit = false;

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
                HLDS.RealTime = 0.0;
                SV.Time = 0.0;
            }
        }

        public static bool Frame()
        {
            SetHostTimes();

            bool result = false;
            int TimeStart = 0;
            int TimeEnd = 0;
            int Count = 0;
            bool profile = false;

            if (HLDS.QuitCommandIssued)
                result = false;
            else
            {
                profile = HLDS.host_profile.value != 0;
                if (!profile)
                {
                    Host._Frame(HLDS.HostTimes.Frame);
                    if (HLDS.HostStateInfo != 0)
                    {
                        HLDS.HostStateInfo = 0;
                        CBuf.Execute();
                    }
                }
                else
                {
                    TimeStart = Sys.FloatTime();
                    Host._Frame(HLDS.HostTimes.Frame);
                    TimeEnd = Sys.FloatTime();

                    if (HLDS.HostStateInfo != 0)
                    {
                        HLDS.HostStateInfo = 0;
                        CBuf.Execute();
                    }

                    HLDS.TimeCount += 1;
                    HLDS.TimeTotal = HLDS.TimeTotal + TimeEnd - TimeStart;

                    if (HLDS.TimeCount >= 1000)
                    {
                        Count = 0;
                        for (int i = 0; i < SVS.MaxClients; i++)
                        {
                            if (SVS.Clients[i].Active)
                                Count += 1;
                        }

                        Print("host_profile: bla bla bla"); // TODO

                        HLDS.TimeTotal = 0;
                        HLDS.TimeCount = 0;
                    }
                }
            }

            result = true;

            return result;
        }
    }
}
