namespace StaffLights
{
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using InventorySystem.Items.Usables;
    using Exiled.Events.EventArgs.Player;

    /// <summary>
    /// The example plugin.
    /// </summary>
    public class StaffLights : Plugin<Config>
    {
        private static readonly StaffLights Singleton = new();

        private PlayerHandler playerHandler;

        private StaffLights()
        {
        }

        public static StaffLights Instance => Singleton;

        public override PluginPriority Priority { get; } = PluginPriority.Last;
        /// <inheritdoc/>
        public override void OnEnabled()
        {
            RegisterEvents();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            playerHandler = new PlayerHandler();


            Exiled.Events.Handlers.Player.ChangingRole += playerHandler.OnChangingRole;

        }

        private void UnregisterEvents()
        {

            Exiled.Events.Handlers.Player.ChangingRole -= playerHandler.OnChangingRole;

            playerHandler = null;

        }
    }
}