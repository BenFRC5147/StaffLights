using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Mirror;
using PlayerRoles;
using UnityEngine;
using StaffLights;
using Light = Exiled.API.Features.Toys.Light;

namespace StaffLights;
public class PlayerGlowHandler : MonoBehaviour
{
    private Player _player;
    private Light _glowLight;

    void Awake()
    {
        _player = Player.Get(gameObject);
    }

    void Start(Config config)
    {
        _glowLight = Light.Create(_player.Position, null, null, true, config.Color);
        _glowLight.ShadowEmission = false;
        _glowLight.Range = config.Range;
        _glowLight.Intensity = 0f;
    }

    void Update(Config config)
    {
        if (_player == null || _glowLight == null)
        {
            Destroy(this);
            return;
        }

        if (_player.Role == RoleTypeId.Tutorial && _player.IsGodModeEnabled)
        {
            _glowLight.Intensity = config.Intensity;
            Log.Debug($"Set {_player.Nickname}'s light to {config.Intensity} as they are a tutorial in God Mode");
        } else
        {
            Log.Debug($"Set {_player.Nickname}'s light to 0 as they aren't a tutorial in God Mode");
            _glowLight.Intensity = 0f;
        }

        if (_glowLight.Position == _player.Position) return;

        _glowLight.Position = _player.Position;
    }

    private void OnDestroy()
    {
        _glowLight.Destroy();
        _glowLight = null;
    }
}
