// -----------------------------------------------------------------------
// <copyright file="PlayerHandler.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

using MEC;

using PlayerRoles;

using UnityEngine;


namespace StaffLights
{
    internal sealed class PlayerHandler
    {
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.Player.RemoteAdminAccess && ev.NewRole == RoleTypeId.Tutorial)
            {
                ev.Player.GameObject.AddComponent<PlayerGlowHandler>();
                Log.Debug($"Added Light Component to {ev.Player.Nickname}");
            }
        }
    }
}
