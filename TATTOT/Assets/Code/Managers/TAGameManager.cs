using Code.GameObjects;
using Code.Logic.Events;
using Code.Logic.Watchers;
using Code.ResourcesLoaders;

namespace Code.Managers
{
    public class TAGameManager : TAAbstractManager<TAGameManager>
    {
        /// <summary>
        /// <see cref="TAWorldWatcher"/> created at the <see cref="Start()"/> lifecycle method.
        /// It helps checking the current state of the world by listening to events about it.
        /// </summary>
        private TAWorldWatcher _worldWatcher;
        
        /// <summary>
        /// <see cref="TAWorldManager"/> set in Unity UI. This keep tracks of the world's events
        /// and data. Handles the displayed <see cref="TAWorldMap"/>
        /// </summary>
        public TAWorldManager worldManager;

        public TAOpponentsManager opponentsManager;
        
        private void Start()
        {
            // Create the world watcher component. Doesn't need to be shown in Unity.
            _worldWatcher = gameObject.AddComponent<TAWorldWatcher>();
            
            worldManager.CreateWorld();
            
            TAEventManager.Shared().DidReadyWorldEvent.AddListener(WorldReady);
        }

        private void WorldReady()
        {
            TAEventManager.Shared().PleaseStartGameEvent.Invoke(TAConfigurationLoader.GetConfiguration().numberOfOpponents + 1);
        }
    }
}
