using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    static class SV
    {
        private static void CheckVoiceChanges()
        {

        }

        private static void GatherStatistics()
        {
            //
        }

        public static void Frame()
        {
            if (Global.SV.Active)
            {
                // GlobalVars.FrameTime := HostFrameTime;
                Global.SV.PrevTime = Global.SV.Time;
                if (Global.ToggleCheats)
                    Global.AllowCheats = Global.sv_cheats.value != 0;

                SV.CheckCmdTimes();
                SV.ReadPackets();
                if (!Global.SV.Paused)
                {
                    SV.Physics();
                    Global.SV.Time = Global.SV.Time + Global.HostFrameTime;
                }

                SV.QueryMovevarsChanged();
                SV.RequestMissingResourcesFromClients();
                SV.CheckTimeouts();
                SV.CheckVoiceChanges();
                SV.SendClientMessages();
                SV.GatherStatistics();
            }
        }

        public static void ServerDeactivate() { }
        public static void ActivateServer(bool NewUnit) { }
        public static bool SpawnServer(string map, string startSpot)
        {
            return false;
        }

        public static void Init()
        {
            // banid, removeid, listid, writeid, resetrcon
            Cmd.AddCommand("logaddress", SetLogAddress_F);
            Cmd.AddCommand("logaddress_add", AddLogAddress_F);
            Cmd.AddCommand("logaddress_del", DelLogAddress_F);
            Cmd.AddCommand("log", ServerLog_F);
            Cmd.AddCommand("serverinfo", Serverinfo_F);
            Cmd.AddCommand("localinfo", Localinfo_F);
            Cmd.AddCommand("showinfo", ShowServerinfo_F);
            Cmd.AddCommand("user", User_F);
            Cmd.AddCommand("users", Users_F);
            Cmd.AddCommand("dlfile", BeginFileDownload_F);
            // addip, removeip, listip, writeip
            Cmd.AddCommand("dropclient", Drop_F);
            Cmd.AddCommand("spawn", Spawn_F);
            Cmd.AddCommand("new", New_F);
            Cmd.AddCommand("sendres", SendRes_F);
            Cmd.AddCommand("sendents", SendEnts_F);
            Cmd.AddCommand("fullupdate", FullUpdate_F);

            // custom
            Cmd.AddCommand("entcount", ED.Count_F);

            // Custom
            CVar.RegisterVariable(ref Global.sv_allow47p);
            CVar.RegisterVariable(ref Global.sv_allow48p);
            CVar.RegisterVariable(ref Global.sv_maxipsessions);
            CVar.RegisterVariable(ref Global.sv_fullservermsg);
            CVar.RegisterVariable(ref Global.sv_limit_queries);
            //    CVar.RegisterVariable(ref Global.max_query_ips);
            CVar.RegisterVariable(ref Global.sv_enableoldqueries);
            CVar.RegisterVariable(ref Global.sv_mapcycle_length);
            CVar.RegisterVariable(ref Global.sv_secureflag);
            CVar.RegisterVariable(ref Global.sv_sendmapcrc);
            CVar.RegisterVariable(ref Global.sv_fullupdateinterval);
            CVar.RegisterVariable(ref Global.sv_sendentsinterval);
            CVar.RegisterVariable(ref Global.sv_sendresinterval);
            CVar.RegisterVariable(ref Global.sv_pinginterval);
            CVar.RegisterVariable(ref Global.sv_updatetime);
            CVar.RegisterVariable(ref Global.sv_keepframes);

            // Resource
            CVar.RegisterVariable(ref Global.sv_allowdownload);
            CVar.RegisterVariable(ref Global.sv_allowupload);
            CVar.RegisterVariable(ref Global.sv_uploadmax);
            CVar.RegisterVariable(ref Global.sv_uploadmaxnum);
            CVar.RegisterVariable(ref Global.sv_uploadmaxsingle);
            CVar.RegisterVariable(ref Global.sv_uploaddecalsonly);
            CVar.RegisterVariable(ref Global.sv_send_logos);
            CVar.RegisterVariable(ref Global.sv_send_resources);

            // SVClient
            CVar.RegisterVariable(ref Global.sv_defaultplayername);
            CVar.RegisterVariable(ref Global.sv_use2asnameprefix);
            CVar.RegisterVariable(ref Global.sv_maxupdaterate);
            CVar.RegisterVariable(ref Global.sv_minupdaterate);
            CVar.RegisterVariable(ref Global.sv_defaultupdaterate);
            CVar.RegisterVariable(ref Global.sv_maxrate);
            CVar.RegisterVariable(ref Global.sv_minrate);
            CVar.RegisterVariable(ref Global.sv_defaultrate);
            CVar.RegisterVariable(ref Global.sv_failuretime);

            // SVEdict
            CVar.RegisterVariable(ref Global.sv_instancedbaseline);

            // SVMain custom
            CVar.RegisterVariable(ref Global.sv_stats);
            CVar.RegisterVariable(ref Global.sv_statsinterval);

            // SVMove
            CVar.RegisterVariable(ref Global.sv_maxunlag);
            CVar.RegisterVariable(ref Global.sv_unlag);
            CVar.RegisterVariable(ref Global.sv_unlagpush);
            CVar.RegisterVariable(ref Global.sv_unlagsamples);
            CVar.RegisterVariable(ref Global.sv_unlagjitter);
            CVar.RegisterVariable(ref Global.sv_cmdcheckinterval);



            // Default

            CVar.RegisterVariable(ref Global.sv_voicecodec);
            CVar.RegisterVariable(ref Global.sv_voiceenable);
            CVar.RegisterVariable(ref Global.sv_voicequality);
            CVar.RegisterVariable(ref Global.rcon_password);
            CVar.RegisterVariable(ref Global.mp_consistency);
            CVar.RegisterVariable(ref Global.sv_contact);
            CVar.RegisterVariable(ref Global.sv_region);
            CVar.RegisterVariable(ref Global.sv_filterban);
            CVar.RegisterVariable(ref Global.sv_logrelay);
            CVar.RegisterVariable(ref Global.sv_lan);
            CVar.RegisterVariable(ref Global.sv_lan_rate);
            CVar.RegisterVariable(ref Global.sv_proxies);
            CVar.RegisterVariable(ref Global.sv_outofdatetime);
            CVar.RegisterVariable(ref Global.sv_visiblemaxplayers);
            CVar.RegisterVariable(ref Global.sv_password);
            CVar.RegisterVariable(ref Global.sv_aim);
            // hblood/hgibs skipped
            CVar.RegisterVariable(ref Global.sv_newunit);

            CVar.RegisterVariable(ref Global.sv_gravity);
            CVar.RegisterVariable(ref Global.sv_friction);
            CVar.RegisterVariable(ref Global.edgefriction);
            CVar.RegisterVariable(ref Global.sv_stopspeed);
            CVar.RegisterVariable(ref Global.sv_maxspeed);
            CVar.RegisterVariable(ref Global.mp_footsteps);
            CVar.RegisterVariable(ref Global.sv_accelerate);
            CVar.RegisterVariable(ref Global.sv_stepsize);
            CVar.RegisterVariable(ref Global.sv_bounce);
            CVar.RegisterVariable(ref Global.sv_airmove);
            CVar.RegisterVariable(ref Global.sv_airaccelerate);
            CVar.RegisterVariable(ref Global.sv_wateraccelerate);
            CVar.RegisterVariable(ref Global.sv_waterfriction);

            CVar.RegisterVariable(ref Global.sv_skycolor_r);
            CVar.RegisterVariable(ref Global.sv_skycolor_g);
            CVar.RegisterVariable(ref Global.sv_skycolor_b);
            CVar.RegisterVariable(ref Global.sv_skyvec_x);
            CVar.RegisterVariable(ref Global.sv_skyvec_y);
            CVar.RegisterVariable(ref Global.sv_skyvec_z);

            CVar.RegisterVariable(ref Global.sv_timeout);
            CVar.RegisterVariable(ref Global.sv_clienttrace);
            CVar.RegisterVariable(ref Global.sv_zmax);
            CVar.RegisterVariable(ref Global.sv_wateramp);
            CVar.RegisterVariable(ref Global.sv_skyname);
            CVar.RegisterVariable(ref Global.sv_maxvelocity);
            CVar.RegisterVariable(ref Global.sv_cheats);

            if (COM.CheckParm("-dev") > 0)
                CVar.DirectSet(ref Global.sv_cheats, "1");

            CVar.RegisterVariable(ref Global.sv_spectatormaxspeed);

            CVar.RegisterVariable(ref Global.sv_logbans);

            CVar.RegisterVariable(ref Global.mapcyclefile);
            CVar.RegisterVariable(ref Global.motdfile);
            CVar.RegisterVariable(ref Global.servercfgfile);
            CVar.RegisterVariable(ref Global.mapchangecfgfile);
            CVar.RegisterVariable(ref Global.lservercfgfile);
            CVar.RegisterVariable(ref Global.logsdir);
            CVar.RegisterVariable(ref Global.bannedcfgfile);
            // rcon skipped

            //      CVar.RegisterVariable(ref Global.max_queries_sec);
            //      CVar.RegisterVariable(ref Global.max_queries_sec_global);
            //      CVar.RegisterVariable(ref Global.max_queries_window);

            CVar.RegisterVariable(ref Global.sv_logblocks);
            CVar.RegisterVariable(ref Global.sv_downloadurl);
            CVar.RegisterVariable(ref Global.sv_version);

            // for I := 0 to MAX_MODELS - 1 do
            //        begin
            //        LocalModels[I][1] := '*';
            // IntToStr(I, LocalModels[I][2], SizeOf(LocalModels[I]) - 1);
            // end;

            //       SVS.Secure := 0;

            //  for I := 0 to SVS.MaxClientsLimit - 1 do
            //         SV_ClearClient(SVS.Clients[I]);


            // PM.Init(@ServerMove);
            // SV.AllocClientFrames;
            InitDeltas();
            // SV.InitRateFilter;

        }
        public static void Shutdown() { }




















        public static void SetLogAddress_F() { }
        public static void AddLogAddress_F() { }
        public static void DelLogAddress_F() { }
        public static void ServerLog_F() { }

        public static void Serverinfo_F() { }
        public static void Localinfo_F() { }
        public static void ShowServerinfo_F() { }

        public static void User_F() { }
        public static void Users_F() { }

        public static void Drop_F() { }

        public static void New_F() { }
        public static void Spawn_F() { }
        public static void SendRes_F() { }
        public static void SendEnts_F() { }
        public static void FullUpdate_F() { }

        // SVDelta.pas

        public static void InitDeltas() { }
        // public static void SV_WriteDeltaDescriptionsToClient(var SB: TSizeBuf);

        // public static void ParseDelta(var C: TClient);


        // Resource.pas

        public static void SetResourceLists(ref Client c) { }
        public static void ClearResourceLists(ref Client c) { }

        // public static void ClearCustomizationList(var List: TCustomization);

        public static void CreateResourceList() { }
        public static void CreateGenericResources() { }
        public static void TransferConsistencyInfo() { }
        public static void RequestMissingResourcesFromClients() { }

        public static void ParseResourceList(ref Client c) { }
        public static void ParseConsistencyResponse(ref Client c) { }
        public static void ProcessFile(ref Client c, string name) { }

        public static void BeginFileDownload_F() { }



        // SVPacket.pas

        public static bool CheckChallenge(NetAdr addr, UInt32 Challenge, bool Reject)
        {
            return false;
        }

        public static void RejectConnection(NetAdr addr, string msg)
        {

        }

        public static UInt32 GetFragmentSize(Client c)
        {
            return 0;
        }

        public static void HandleRconPacket() { }
        public static bool FilterPacket()
        {
            return false;
        }

        public static void ReadPackets()
        {
            while (NET.GetPacket(NetSrc.NS_SERVER))
            {
                if (SV.FilterPacket())
                    SV.SendBan();
                else
                    //       if PInt32(NetMessage.Data) ^ = OUTOFBAND_TAG then
                    //          SV.ConnectionlessPacket()
                    //      else
                    for (int i = 0; i < Global.SVS.MaxClients; i++)
                    {
                        Client C = null;
                        //C := @SVS.Clients[I];
                        if ((C.Active || C.Spawned || C.Connected) && NET.CompareAdr(Global.NetFrom, C.netchan.Addr))
                        {
                            if (Netchan.Process(ref C.netchan))
                            {
                                if ((Global.SVS.MaxClients == 1) || !C.Active || !C.Spawned || !C.SendInfo)
                                    C.NeedUpdate = true;

                                SV.ExecuteClientMessage(ref C);
                                Global.GlobalVars.FrameTime = (float)Global.HostFrameTime;
                            }

                            if (Netchan.IncomingReady(C.netchan))
                            {
                                if (Netchan.CopyNormalFragments(ref C.netchan))
                                {
                                    MSG.BeginReading();
                                    SV.ExecuteClientMessage(ref C);
                                }

                                if (Netchan.CopyFileFragments(ref C.netchan))
                                {
                                    //  Global.HostClient = C;
                                    SV.ProcessFile(ref C, C.netchan.FileName);
                                }
                            }

                            break;
                        }
                    }
            }

        }


        // SVMove.pas


        public static bool CheckBottom(Edict e)
        {
            return false;
        }

        public static bool MoveTest(ref Edict e, Vec3 Move, bool Relink)
        {
            return false;
        }

        public static bool MoveStep(ref Edict e, Vec3 Move, bool Relink)
        {
            return false;
        }

        public static void MoveToOrigin(ref Edict e, Vec3 Target, float Distance, int MoveType)
        {

        }

        public static void SetGlobalTrace(Trace T)
        {

        }
        public static uint PointLeafnum(Vec3 P)
        {
            return 0;
        }

        public static void GetTrueOrigin(uint Index, out Vec3 Origin)
        {
            Origin = new Vec3();
        }

        public static void GetTrueMinMax(uint Index, out Vec3 MinS, out Vec3 MaxS)
        {
            MinS = new Vec3();
            MaxS = new Vec3();
        }

        // public static void PM_SV_PlaySound(Channel: Int32; Sample: PLChar; Volume, Attn: Single; Flags, Pitch: Int32);
        //  function PM_SV_TraceTexture(Ground: Int32; const VStart, VEnd: TVec3): PLChar;
        // public static void PM_SV_PlaybackEventFull(Flags, ClientIndex: Int32; EventIndex: UInt16; Delay: Single; const Origin, Angles: TVec3; FParam1, FParam2: Single; IParam1, IParam2, BParam1, BParam2: Int32);

        public static void CheckCmdTimes() { }
        public static void PreRunCmd() { }
        public static void RunCmd(ref UserCmd cmd, UInt32 RandomSeed) { }

        public static void SetupMove(ref Client c) { }
        public static void RestoreMove(ref Client c) { }

        //   function SV_FatPVS(const Origin: TVec3): PByte;
        //  function SV_FatPAS(const Origin: TVec3): PByte;

        public static void SetMoveVars() { }
        public static void QueryMovevarsChanged() { }

        public static void ComputeLatency(ref Client c) { }

        // public static void EstablishTimeBase(ref Client c; Cmd: PUserCmdArray; Drop, Backup, NumCmds: UInt);
        public static void ParseMove(ref Client c) { }




        // SVPhys.pas


        public static void CheckVelocity(ref Edict E) { }
        public static bool RunThink(ref Edict E)
        {
            return false;
        }

        public static bool CheckWater(ref Edict E)
        {
            return false;
        }

        public static void Impact(ref Edict E1, ref Edict E2, Trace trace) { }
        public static void Physics() { }

        // public static ref Trace Trace_Toss(out Trace trace, Edict E IgnoreEnt: PEdict): PTrace;
        public static string TraceTexture(ref Edict E, Vec3 v1, Vec3 v2)
        {
            return "";
        }






        // SVClient.pas

        public static uint CountPlayers()
        {
            return 0;
        }

        public static uint CountProxies()
        {
            return 0;
        }

        public static uint CountFakeClients()
        {
            return 0;
        }

        public static uint CalcPing(Client C)
        {
            return 0;
        }

        public static void InitClient(ref Client C)
        {

        }

        public static void ClearClient(ref Client C)
        {

        }

        public static void ClearClients()
        {
            //
        }

        public static void DropClient(ref Client C, bool SkipNotify, string Msg)
        {
            //
        }

        public static void BroadcastCommand(string S)
        {

        }

        public static void BroadcastPrint(string Msg)
        {

        }

        public static void SkipUpdates() { }

        public static void SendBan() { }

        public static bool FilterPlayerName(string Name, int IgnoreClient = -1)
        {
            return false;
        }

        public static void ExtractFromUserInfo(ref Client C)
        {

        }

        public static void FullClientUpdate(Client C, ref SizeBuf SB)
        {

        }

        public static void ForceFullClientsUpdate()
        {

        }

        public static void ClientPrint(ref Client C, string Msg, bool LineBreak = true)
        {

        }

        public static void ClientPrint(string Msg, bool LineBreak = true)
        {

        }

        public static void CmdPrint(string Msg)
        {

        }

        public static void WriteSpawn(ref Client C, ref SizeBuf SB)
        {

        }

        public static void WriteVoiceCodec(ref SizeBuf SB)
        {

        }

        public static void SendServerInfo(ref SizeBuf SB, ref Client C)
        {

        }

        public static void SendResources(ref SizeBuf SB)
        {

        }

        public static void BuildReconnect(ref SizeBuf SB)
        {

        }

        public static bool IsPlayerIndex(uint i)
        {
            return false;
        }

        public static void ClearClientStates() { }
        public static void InactivateClients() { }

        public static void ClearPacketEntities(ref ClientFrame Frame, bool ForceFree) { }
        public static void AllocPacketEntities(ref ClientFrame Frame, uint NumEnts) { }
        public static void ClearFrames(ref Client C) { }
        public static void AllocFrames(ref Client C) { }
        public static void ClearClientFrames() { }

        public static void SetMaxClients() { }

        public static void ParseStringCommand(ref Client C) { }
        public static void ParseVoiceData(ref Client C) { }
        public static void IgnoreHLTV(ref Client C) { }
        public static void ParseCVarValue(ref Client C) { }
        public static void ParseCVarValue2(ref Client C) { }

        public static void ExecuteClientMessage(ref Client C) { }

        public static void WriteMoveVarsToClient(ref SizeBuf SB) { }

        public static void CheckTimeouts() { }
        public static bool ShouldUpdatePing(ref Client C)
        {
            return false;
        }

        public static void EmitPings(ref SizeBuf SB)
        {

        }

        public static void SendClientMessages() { }

    }
}
