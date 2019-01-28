using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    static class Global
    {
        // Host.pas

        public static readonly string LangName = "english";
        public static readonly bool LowViolenceBuild = false;

        public static CVar console_cvar = new CVar("console", "0");
        public static CVar developer = new CVar("developer", "0");
        public static CVar deathmatch = new CVar("deathmatch", "0", CVar.Flags.FCVAR_SERVER);
        public static CVar coop = new CVar("coop", "0", CVar.Flags.FCVAR_SERVER);
        public static CVar hostname = new CVar("hostname", "HLDS.NET Server");
        public static CVar skill = new CVar("skill", "1");
        public static CVar hostmap = new CVar("hostmap");
        public static CVar host_killtime = new CVar("host_killtime", "0");
        public static CVar sys_ticrate = new CVar("sys_tickrate", "100", CVar.Flags.FCVAR_SERVER);
        public static CVar sys_maxframetime = new CVar("sys_maxframetime", "0.25");
        public static CVar sys_minframetime = new CVar("sys_minframetime", "0.001");
        public static CVar sys_timescale = new CVar("sys_timescale", "1");
        public static CVar host_limitlocal = new CVar("host_limitlocal", "0");
        public static CVar host_framerate = new CVar("host_framerate", "0");
        public static CVar host_speeds = new CVar("host_speeds", "0");
        public static CVar host_profile = new CVar("host_profile", "0");
        public static CVar pausable = new CVar("pausable", "0", CVar.Flags.FCVAR_SERVER);

        public static bool HostInit = false;
        public static uint HostActive;
        public static uint HostSubState;
        public static uint HostStateInfo;
        public static bool QuitCommandIssued;
        public static bool InHostError;
        public static bool InHostShutdown;
        public static uint HostHunkLevel;
        public static double HostFrameTime;
        public static uint HostNumFrames;

        public static double RealTime;
        public static double OldRealTime;

        public static string BaseDir;
        public static string GameDir;
        public static string DefaultGameDir;
        public static string FallbackDir;

        public static bool CSFlagsInitialized = false;
        public static bool IsCStrike;
        public static bool IsCZero;
        public static bool IsCZeroRitual;
        public static bool IsTerrorStrike;

        public static string WADPath;

        public struct THostTimes
        {
            public double Cur;
            public double Prev;
            public double Frame;
            public bool CollectData;// = false;
            public double Host;
            public double SV;
            public double Rcon;
        }

        public static THostTimes HostTimes;
        
        public static uint TimeCount;
        public static double TimeTotal;

        public static bool CmdLineTicrateCheck = false;
        public static uint CmdLineTicrate;

        public static double RollingFPS;

        // HPAK.pas

        public static CVar hpk_maxsize = new CVar("hpk_maxsize", "4", CVar.Flags.FCVAR_ARCHIVE);

        // Server.pas


        public static CVar sv_aim = new CVar("sv_aim", "1", CVar.Flags.FCVAR_ARCHIVE);
        public static CVar sv_clienttrace = new CVar("sv_clienttrace", "1");
        public static CVar sv_lan = new CVar("sv_lan", "0", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_lan_rate = new CVar("sv_lan_rate", "20000");

        public static CVar sv_logbans = new CVar("sv_logbans", "1");
        public static CVar sv_log_onefile = new CVar("sv_log_onefile", "0");
        public static CVar sv_log_singleplayer = new CVar("sv_log_singleplayer", "0");
        public static CVar sv_log_altdateformat = new CVar("sv_log_altdateformat", "0");
        public static CVar mp_logecho = new CVar("mp_logecho", "1");
        public static CVar mp_logfile = new CVar("mp_logfile", "1");

        public static CVar logsdir = new CVar("logsdir", "logs");
        public static CVar mapcyclefile = new CVar("mapcyclefile", "mapcycle.txt");
        public static CVar motdfile = new CVar("motdfile", "motd.txt");
        public static CVar servercfgfile = new CVar("servercfgfile", "server.cfg");
        public static CVar mapchangecfgfile = new CVar("mapchangecfgfile", "");
        public static CVar lservercfgfile = new CVar("lservercfgfile", "listenserver.cfg");
        public static CVar bannedcfgfile = new CVar("bannedcfgfile", "banned.cfg");

        public static CVar mp_footsteps = new CVar("mp_footsteps", "1", CVar.Flags.FCVAR_SERVER);

        public static CVar sv_voicecodec = new CVar("sv_voicecodec", "voice_speex", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_voiceenable = new CVar("sv_voiceenable", "1", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_voicequality = new CVar("sv_voicequality", "5", CVar.Flags.FCVAR_SERVER);

        public static CVar mp_consistency = new CVar("mp_consistency", "1", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_downloadurl = new CVar("sv_downloadurl", "", CVar.Flags.FCVAR_PROTECTED);

        public static CVar sv_filterban = new CVar("sv_filterban", "1");
        public static CVar sv_outofdatetime = new CVar("sv_outofdatetime", "1800"); // outdated?
        public static CVar sv_visiblemaxplayers = new CVar("sv_visiblemaxplayers", "-1");
        public static CVar sv_timeout = new CVar("sv_timeout", "60", CVar.Flags.FCVAR_SERVER);

        public static CVar sv_newunit = new CVar("sv_newunit", "0");
        public static CVar sv_password = new CVar("sv_password", "", CVar.Flags.FCVAR_SERVER | CVar.Flags.FCVAR_PROTECTED);

        public static CVar sv_cheats = new CVar("sv_cheats", "0", CVar.Flags.FCVAR_SERVER);

        public static CVar sv_version = new CVar("sv_version", "", CVar.Flags.FCVAR_SERVER);

        // custom
        public static CVar sv_sendmapcrc = new CVar("sv_sendmapcrc", "1");
        public static CVar sv_mapcycle_length = new CVar("sv_mapcycle_length", "8192");
        public static CVar sv_secureflag = new CVar("sv_secureflag", "0", CVar.Flags.FCVAR_SERVER);

        public static CVar sv_sendentsinterval = new CVar("sv_sendentsinterval", "0.75");
        public static CVar sv_sendresinterval = new CVar("sv_sendresinterval", "1.35");
        public static CVar sv_fullupdateinterval = new CVar("sv_fullupdateinterval", "1.1");

        public static bool AllowCheats = false; // SV_SpawnServer
        public static bool ToggleCheats = false;
 
        public static uint SVDecalNameCount;
        //SVDecalNames: array[0..MAX_DECAL_NAMES - 1] of array[1..MAX_LUMP_NAME + 1] of LChar;

        public static uint SVUpdateBackup = 8;
        public static uint SVUpdateMask = 7;

    }
}
