using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Exiled.Events.Handlers;
using GServer = Exiled.Events.Handlers.Server;
using GPlayer = Exiled.Events.Handlers.Player;
using Exiled.Events;

//The plugins was going to be a Voting system but then i decided that is going to be a toolbox.
namespace VotingSystem
{
    public class DupecToolbox : Plugin<Config>
    {
        private Handlers.Player player;


        private static readonly Lazy<DupecToolbox> LazyInstance = new Lazy<DupecToolbox>(valueFactory: () => new DupecToolbox());
        public static DupecToolbox Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private DupecToolbox()
        {

        }

        public override void OnEnabled()
        {

            Log.Info(message: "Demotion System Starting");
            registerEvents();
        }
        public override void OnDisabled()
        {
            Log.Info(message: "Bye Bye!");
            UnregisterEvents();
        }
        public void registerEvents()
        {
            player = new Handlers.Player();

            GPlayer.Died += player.killing;

        }

        public void UnregisterEvents()
        {
            player = new Handlers.Player();

            GPlayer.Died -= player.killing;
            

            player = null;
        }
    }
}