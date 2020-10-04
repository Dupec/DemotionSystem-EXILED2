using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;
using PlayableScps;
using System;
using MEC;
using UnityEngine;

namespace VotingSystem.Handlers
{
    class Player
    {
        public static int playerExp = 100;

        public static int maxExp = DupecToolbox.Instance.Config.MaxReputation;
        public static int minExp = DupecToolbox.Instance.Config.MinReputation;
        public static int maxRange = DupecToolbox.Instance.Config.maxRange;
        public static int minRange = DupecToolbox.Instance.Config.minRange;
        public bool promotion_enabled = DupecToolbox.Instance.Config.promotion_enabled;
        public bool demotion_enabled = DupecToolbox.Instance.Config.demotion_enabled;
        public void killing(DiedEventArgs ev)
        {
            if (ev.Target.IsNTF && ev.Killer.IsNTF)
            {
                System.Random rnd = new System.Random();
                int xp2add = rnd.Next(1, 37);
                playerExp -= xp2add;
                if (demotion_enabled)
                {
                    if (playerExp <= 0)
                    {
                        if (ev.Killer.Role == RoleType.NtfCommander)
                        {
                            string message = VotingSystem.DupecToolbox.Instance.Config.DemotionNTFLieutenant;
                            ushort time = VotingSystem.DupecToolbox.Instance.Config.MessagesDuration;
                            ev.Killer.Broadcast(time, message);
                            float x = ev.Killer.Position.x;
                            float y = ev.Killer.Position.y;
                            float z = ev.Killer.Position.z;
                            ev.Killer.SetRole(RoleType.Spectator);
                            ev.Killer.SetRole(RoleType.NtfLieutenant);
                            Timing.CallDelayed(0.4f, () =>
                            {
                                ev.Killer.Position = new UnityEngine.Vector3(x, y, z);
                            });
                        }
                        else if (ev.Killer.Role == RoleType.NtfLieutenant)
                        {
                            string message = VotingSystem.DupecToolbox.Instance.Config.DemotionNTFCadet;
                            ushort time = VotingSystem.DupecToolbox.Instance.Config.MessagesDuration;
                            ev.Killer.Broadcast(time, message);
                            float x = ev.Killer.Position.x;
                            float y = ev.Killer.Position.y;
                            float z = ev.Killer.Position.z;
                            ev.Killer.SetRole(RoleType.Spectator);
                            ev.Killer.SetRole(RoleType.NtfCadet);
                            Timing.CallDelayed(0.4f, () =>
                            {
                                ev.Killer.Position = new UnityEngine.Vector3(x, y, z);
                            });
                        }
                        else if (ev.Killer.Role == RoleType.NtfCadet)
                        {
                            string message = VotingSystem.DupecToolbox.Instance.Config.DemotionNTFFG;
                            ushort time = VotingSystem.DupecToolbox.Instance.Config.MessagesDuration;
                            ev.Killer.Broadcast(time, message);
                            float x = ev.Killer.Position.x;
                            float y = ev.Killer.Position.y;
                            float z = ev.Killer.Position.z;
                            ev.Killer.SetRole(RoleType.Spectator);
                            ev.Killer.SetRole(RoleType.FacilityGuard);
                            Timing.CallDelayed(0.4f, () =>
                            {
                                ev.Killer.Position = new UnityEngine.Vector3(x, y, z);
                            });
                        }
                        playerExp = 100;
                    }
                }

            }
            else if (!ev.Target.IsNTF && ev.Killer.IsNTF)
            {
                System.Random rnd = new System.Random();
                int xp2add = rnd.Next(minRange, maxRange);
                playerExp += xp2add;
                if (promotion_enabled)
                {
                    if (playerExp >= maxExp)
                    {
                        if (ev.Killer.Role == RoleType.FacilityGuard)
                        {
                            string message = VotingSystem.DupecToolbox.Instance.Config.PromotionNTFCadet;
                            ushort time = VotingSystem.DupecToolbox.Instance.Config.MessagesDuration;
                            ev.Killer.Broadcast(time, message);
                            float x = ev.Killer.Position.x;
                            float y = ev.Killer.Position.y;
                            float z = ev.Killer.Position.z;
                            ev.Killer.SetRole(RoleType.Spectator);
                            ev.Killer.SetRole(RoleType.NtfCadet);
                            Timing.CallDelayed(0.4f, () =>
                            {
                                ev.Killer.Position = new UnityEngine.Vector3(x, y, z);
                            });
                        }
                        else if (ev.Killer.Role == RoleType.NtfCadet)
                        {
                            string message = VotingSystem.DupecToolbox.Instance.Config.PromotionNTFLieutenant;
                            ushort time = VotingSystem.DupecToolbox.Instance.Config.MessagesDuration;
                            ev.Killer.Broadcast(time, message);
                            float x = ev.Killer.Position.x;
                            float y = ev.Killer.Position.y;
                            float z = ev.Killer.Position.z;
                            ev.Killer.SetRole(RoleType.Spectator);
                            ev.Killer.SetRole(RoleType.NtfLieutenant);
                            Timing.CallDelayed(0.4f, () =>
                            {
                                ev.Killer.Position = new UnityEngine.Vector3(x, y, z);
                            });
                        }
                        playerExp = 100;
                    }
                }
            }
        }
    }
}