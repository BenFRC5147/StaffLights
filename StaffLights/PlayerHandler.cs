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


public static class ExtensionMethods
{
    public static void RemoveComponent<Component>(this GameObject obj, bool immediate = false)
    {
        Component component = obj.GetComponent<Component>();

        if (component != null)
        {
            if (immediate)
            {
                Object.DestroyImmediate(component as Object, true);
            }
            else
            {
                Object.Destroy(component as Object);
            }

        }
    }
}

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
            }else
            {
                ev.Player.GameObject.RemoveComponent<PlayerGlowHandler>();
                Log.Debug($"Removed Light Component from {ev.Player.Nickname}");
            }
        }
    }
}