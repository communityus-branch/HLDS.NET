using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    class Client
    {
        public bool Active; // +0, cf
        public bool Spawned; // +4, cf
        public bool SendInfo; // +8 cf
        public bool Connected; // +12 cf
        public bool HasMissingResources; // +16 cf (need missing resources)
        public bool UserMsgReady; // +20 cf SV_New
        public bool NeedConsistency; // +24 cf

        public Netchan netchan; // +32?  124 is netmessage (92 + 32)
        public UInt32 ChokeCount; // 9536 W, cf, unsigned
        public Int32 UpdateMask; // 9540 W, cf signed
        public bool FakeClient; // 9272 L 9544 W
        public bool HLTV; // 9548 W, cf
        public UserCmd usercmd; // 9552 W, cf  size 52

        public double FirstCmd; // 9608 W, cf
        public double LastCmd; // 9616 W, cf
        public double NextCmd; // 9624 W, cf
        public float Latency; // 9632 W, cf, single (ping)
        public float PacketLoss; // 9636 W, cf, single

        public double NextPingTime; // 9648 W, cf, double
        public double ClientTime;  // 9656 W, cf, double
       // UnreliableMessage: TSizeBuf; // 9664 W, yep
       // UnreliableMessageData: array[1..MAX_DATAGRAM] of Byte; // 9684.. or more?

        public double ConnectTime; // +13688 W cf
        public double NextUpdateTime; // +13696 W cf
        public double UpdateRate; // +13704 W cf        13424 L

        // ->
        public bool NeedUpdate; // 13712 W cf
        public bool SkipThisUpdate; // 13436 L  13716 W
       // Frames: TClientFrameArrayPtr; // 13720 W
       // Events: TEventState; // 13724 W cf

        // client edict pointer
      //  Entity: PEdict; // 19356 W cf
      //  Target: PEdict; // view entity, 19360 W cf
        public UInt32 UserID; // 19364 W cf

        public struct Auth
        {
            //  public AuthType: TAuthType; // +19368 cf
            // ?
            public Int64 UniqueID;   // +19376 cf
            public NetIp IP; // +19384 cf
        
        }

        public Auth auth;
        
        // <-

    //    UserInfo: array[1..MAX_USERINFO_STRING] of LChar; // 19392 W cf
        public bool UpdateInfo; // 19648 W cf
        public float UpdateInfoTime; // 19652 W
       // CDKey: array[1..64] of LChar; // +19656 cf
       // NetName: array[1..32] of LChar; // 19720 W cf
        public Int32 TopColor; // 19752 W cf
        public Int32 BottomColor; // 19756 W cf

        // server -> client
      //  DownloadList: TResource; // +19476 L   +19764 W
        // client -> server
      //  UploadList: TResource; // +19612 L   +19900 W
        public bool UploadComplete; // +20040 W cf
       // Customization: TCustomization; // +20044 W cf

       // MapCRC: TCRC; // +20208 W cf
        public bool LW; // weapon prediction;  +20212 W
        public bool LC; // lag compensation; +20216 W
       // PhysInfo: array[1..256] of LChar; // +20220 W cf

        public bool VoiceLoopback; // +20476 cf
       // BlockedVoice: set of 0..MAX_PLAYERS - 1; // +20480 W cf



        // Custom fields
        public byte Protocol; // for double-protocol support

        // filters
        public double SendResTime;
        public double SendEntsTime;
        public double FullUpdateTime;

        // an experimental filter for "new" command, it restricts the command to being sent only once during the single server sequence.
        public UInt32 ConnectSeq;
        public UInt32 SpawnSeq;

        public double NewCmdTime;
        public double SpawnCmdTime;

        public uint FragSize;
        public bool FragSizeUpdated; // is it necessary to update the fragsize
    }
}
