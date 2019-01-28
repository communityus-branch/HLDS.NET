using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    static class Global
    {
        // Main.pas

        public static bool ShutdownCalled = false;

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

        public static class HostTimes
        {
            public static double Cur;
            public static double Prev;
            public static double Frame;
            public static bool CollectData = false;
            public static double Host;
            public static double SV;
            public static double Rcon;
        }
        
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


        // SVPacket.pas

        public static CVar sv_contact = new CVar("sv_contact", "", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_region = new CVar("sv_region", "1", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_logblocks = new CVar("sv_logblocks", "0");
        public static CVar sv_logrelay = new CVar("sv_logrelay", "0");
        public static CVar sv_proxies = new CVar("sv_proxies", "2", CVar.Flags.FCVAR_SERVER);

        public static CVar sv_allow47p = new CVar("sv_allow47p", "1", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_allow48p = new CVar("sv_allow48p", "1", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_maxipsessions = new CVar("sv_maxipsessions", "5");
        public static CVar sv_fullservermsg = new CVar("sv_fullservermsg", "Server is full.");

        public static CVar ipf_min_samples = new CVar("ipf_min_samples", "25", CVar.Flags.FCVAR_SERVER | CVar.Flags.FCVAR_PROTECTED);
        public static CVar ipf_max_queries_sec = new CVar("ipf_max_queries_sec", "10", CVar.Flags.FCVAR_SERVER | CVar.Flags.FCVAR_PROTECTED);
        public static CVar ipf_timeout = new CVar("ipf_timeout", "5", CVar.Flags.FCVAR_SERVER | CVar.Flags.FCVAR_PROTECTED);

        public static CVar sv_limit_queries = new CVar("sv_limit_queries", "0");

        public static CVar sv_enableoldqueries = new CVar("sv_enableoldqueries", "1");


        // SVClient.pas


        public static CVar sv_defaultplayername = new CVar("sv_defaultplayername", "unnamed");
        public static CVar sv_use2asnameprefix = new CVar("sv_use2asnameprefix", "0");

        public static CVar sv_defaultupdaterate = new CVar("sv_defaultupdaterate", "45");
        public static CVar sv_maxupdaterate = new CVar("sv_maxupdaterate", "90", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_minupdaterate = new CVar("sv_minupdaterate", "10", CVar.Flags.FCVAR_SERVER);

        public static CVar sv_defaultrate = new CVar("sv_defaultrate", "10000");
        public static CVar sv_maxrate = new CVar("sv_maxrate", "25000", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_minrate = new CVar("sv_minrate", "3500", CVar.Flags.FCVAR_SERVER);

        public static CVar sv_failuretime = new CVar("sv_failuretime", "0.5");

        // how often to send ping reports to the clients
        public static CVar sv_pinginterval = new CVar("sv_pinginterval", "1.0");

        // min interval between sending userinfo broadcast updates
        public static CVar sv_updatetime = new CVar("sv_updatetime", "1.0");

        // allocate client frames only once, thereby increasing memory consumption,
        // but reducing overhead
        public static CVar sv_keepframes = new CVar("sv_keepframes", "1");

        public static uint CurrentUserID = 1;

        
        // Resource.pas

        public static CVar sv_allowdownload = new CVar("sv_allowdownload", "1", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_allowupload = new CVar("sv_allowupload", "1", CVar.Flags.FCVAR_SERVER);

        public static CVar sv_uploadmax = new CVar("sv_uploadmax", "0.5", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_uploadmaxnum = new CVar("sv_uploadmaxnum", "16", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_uploadmaxsingle = new CVar("sv_uploadmaxsingle", "0.256", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_uploaddecalsonly = new CVar("sv_uploaddecalsonly", "1", CVar.Flags.FCVAR_SERVER);

        public static CVar sv_send_logos = new CVar("sv_send_logos", "1");
        public static CVar sv_send_resources = new CVar("sv_send_resources", "1");


        // SVEdict.pas

        public static CVar sv_instancedbaseline = new CVar("sv_instancedbaseline", "1");

        // LocalModels: array[0..MAX_MODELS - 1] of array[1..16] of LChar;





        // SVMain.pas


        public static bool AllowCheats = false;
        public static bool ToggleCheats = false;

        public static uint SVDecalNameCount;
       // SVDecalNames: array[0..MAX_DECAL_NAMES - 1] of array[1..MAX_LUMP_NAME + 1] of LChar;

        public static uint SVUpdateBackup = 8;
        public static uint SVUpdateMask = 7;
        public static uint PrevUpdateBackup;

        public static class SV
        {
            public static bool Active; // 0 L, 0 W, cf
            public static bool Paused; // 4 L, 4 W, cf
            public static bool SavedGame; // 8 L, 8 W, cf
            public static double Time; // 12 L, 16 W, cf
            public static double PrevTime; // 20 L, 24 W, cf
            public static Int32 LastPVSClient; // 28 L
            public static double LastPVSCheckTime; // 32 L
         //   Map: array[1..MAX_MAP_NAME] of LChar; // 40 L confirmed
          //  PrevMap: array[1..MAX_MAP_NAME] of LChar; // 104 L cf
          //  StartSpot: array[1..64] of LChar; // 168 L, cf
          //  MapFileName: array[1..MAX_MAP_NAME] of LChar; // 232: maps/%s.bsp / map filename, length = 64
           // WorldModel: PModel; // 296, the map pointer
           // WorldModelCRC: TCRC; // 300 L, cf
           // ClientDLLHash: TMD5Hash; // 304 L, cf
          //  Resources: array[0..MAX_RESOURCES - 1] of TResource; // 320 L, cf
            public static UInt32 NumResources;
        //    PrecachedConsistency: array[0..MAX_CONSISTENCY - 1] of TConsistency; // 174404 probably
            public static UInt32 NumConsistency; // 196932 L cf
       //     PrecachedModelNames: array[0..MAX_MODELS - 1] of PLChar; // 196936
       ///     PrecachedModels: array[0..MAX_MODELS - 1] of PModel; // 198984
        //    PrecachedModelFlags: array[0..MAX_MODELS - 1] of TResourceFlags; // 201032
        //    PrecachedEvents: array[0..MAX_EVENTS - 1] of TPrecachedEvent;
        //    PrecachedSoundNames: array[0..MAX_SOUNDS - 1] of PLChar; // 205640
        //    SoundHashTable: array[0..MAX_SOUNDHASH - 1] of UInt16; // 207688, 1023 entries
            public static bool SoundTableReady; // 209736: sound hashing needed or something
        //    PrecachedGeneric: array[0..MAX_GENERICS - 1] of PLChar; // 209740
        //    PrecachedResGeneric: array[0..MAX_GENERICS - 1] of array[1..64] of LChar; // 211788
            public static UInt32 NumResGeneric; // 244556
        //    LightStyles: array[0..MAX_LIGHTSTYLES - 1] of PLChar; // 244560
            public static UInt32 NumEdicts; // 244816 L
            public static UInt32 MaxEdicts; // 244820 L
        //    Edicts: ^TEdictArray; // 244824 L
        //    EntityState: ^TEntityStateArray; // 244828 L
        //    Baseline: PServerBaseline; // 244832, cf
        //    State: (SS_OFF = 0, SS_LOADING, SS_ACTIVE); // 244836 L
        //    Datagram: TSizeBuf; // 244840 L
        //    DatagramData: array[1..MAX_DATAGRAM] of Byte; // 244860 size cf
        //    ReliableDatagram: TSizeBuf; // 248860 L check check
        //    ReliableDatagramData: array[1..MAX_DATAGRAM] of Byte; // 248880 L size cf
        //    Multicast: TSizeBuf; // 252880 L
        //    MulticastData: array[1..1024] of Byte; // 252900 L size cf
        //    Spectator: TSizeBuf; // 253924 L
        //    SpectatorData: array[1..1024] of Byte; // 253944 L size cf
        //    Signon: TSizeBuf; // 254968 L
        //    SignonData: array[1..32768] of Byte; // 254988 L size not cf

            // custom fields

            public static uint SoundHashCollisions;
            public static uint MulticastSuppressed;
            public static uint MulticastOverflowed;
        } // 287756 on 48patch*/

        public static class SVS
        {
            public static bool InitGameDLL; // +0, confirmed
        //    Clients: ^TClientArray; // +4, confirmed
            public static UInt32 MaxClients;
            public static UInt32 MaxClientsLimit; // +8, +12; confirmed
            public static UInt32 SpawnCount; // +16, confirmed
            public static UInt32 ServerFlags; // +20
            public static bool LogEnabled; // +24
            public static bool LogToAddr; // +28
            public static NetAdr LogAddr; // +32
          //  LogFile: TFile; // +52

            public static class Stats
            {
                public static uint NumStats;
                public static double NextStatUpdate;
                // Fill: array[0..MAX_PLAYERS] of UInt;
                public static uint NumDrops;
                public static uint NumLatency;
                public static double AccumTimePlaying;
                public static double AccumLatency;
                public static double AccumFrames;
            }

            public static UInt32 Secure;
        }

        //   OutOfBandIPF: TIPFilter;

        //   GlobalVars: TGlobalVars;
        //    MoveVars: TMoveVars;

        //    HostClient: PClient;
        //   SVPlayer: PEdict;

        //   NullString: PLChar = #0;
        public static uint PRStrings;
        
        public static CVar sv_stats = new CVar("sv_stats", "1");
        public static CVar sv_statsinterval = new CVar("sv_statsinterval", "30");

        // SVMove.pas

        public static CVar sv_maxunlag = new CVar("sv_maxunlag", "0.5");
        public static CVar sv_unlag = new CVar("sv_unlag", "1", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_unlagpush = new CVar("sv_unlagpush", "0");
        public static CVar sv_unlagsamples = new CVar("sv_unlagsamples", "1");
        public static CVar sv_unlagjitter = new CVar("sv_unlagjitter", "0.2");

        public static CVar sv_cmdcheckinterval = new CVar("sv_cmdcheckinterval", "1");

       // ServerMove: TPlayerMove;

        public static bool AlreadyMoved = false;



        // SVPhys.pas


        public static CVar sv_bounce = new CVar("sv_bounce", "1", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_friction = new CVar("sv_friction", "4", CVar.Flags.FCVAR_SERVER); 
        public static CVar sv_gravity = new CVar("sv_gravity", "800", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_maxvelocity = new CVar("sv_maxvelocity", "2000");
        public static CVar sv_stopspeed = new CVar("sv_stopspeed", "100", CVar.Flags.FCVAR_SERVER);

        public static CVar sv_maxspeed = new CVar("sv_maxspeed", "320", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_spectatormaxspeed = new CVar("sv_spectatormaxspeed", "500");
        public static CVar sv_airmove = new CVar("sv_airmove", "1", CVar.Flags.FCVAR_SERVER);

        public static CVar sv_accelerate = new CVar("sv_accelerate", "10", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_airaccelerate = new CVar("sv_airaccelerate", "10", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_wateraccelerate = new CVar("sv_wateraccelerate", "10", CVar.Flags.FCVAR_SERVER);  

        public static CVar sv_stepsize = new CVar("sv_stepsize", "18", CVar.Flags.FCVAR_SERVER);

        public static CVar edgefriction = new CVar("edgefriction", "2", CVar.Flags.FCVAR_SERVER);
        public static CVar sv_waterfriction = new CVar("sv_waterfriction", "1", CVar.Flags.FCVAR_SERVER);

        public static CVar sv_zmax = new CVar("sv_zmax", "4096", CVar.Flags.FCVAR_SPONLY);
        public static CVar sv_wateramp = new CVar("sv_wateramp", "0");

        public static CVar sv_skyname = new CVar("sv_skyname", "desert");
        public static CVar sv_skycolor_r = new CVar("sv_skycolor_r", "0");
        public static CVar sv_skycolor_g = new CVar("sv_skycolor_g", "0");
        public static CVar sv_skycolor_b = new CVar("sv_skycolor_b", "0");
        public static CVar sv_skyvec_x = new CVar("sv_skyvec_x", "0");
        public static CVar sv_skyvec_y = new CVar("sv_skyvec_y", "0");
        public static CVar sv_skyvec_z = new CVar("sv_skyvec_z", "0");

        public static CVar sv_rollangle = new CVar("sv_rollangle", "0");
        public static CVar sv_rollspeed = new CVar("sv_rollspeed", "200");



        // SVRcon.pas

        public static CVar rcon_password = new CVar("rcon_password", "");
        public static CVar sv_rcon_minfailures = new CVar("sv_rcon_minfailures", "5");
        public static CVar sv_rcon_maxfailures = new CVar("sv_rcon_maxfailures", "10");
        public static CVar sv_rcon_minfailuretime = new CVar("sv_rcon_minfailuretime", "30");
        public static CVar sv_rcon_banpenalty = new CVar("sv_rcon_banpenalty", "0");

       // RedirectType: TRedirectType;
       // RedirectBuf: array[1..MAX_FRAGLEN - 7] of LChar;
        public static NetAdr RedirectTo;

    }
}
