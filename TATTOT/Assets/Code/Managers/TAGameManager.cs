using System;
using Code.GameObjects;
using Code.Logic.Events;
using Code.Managers.Watchers;
using Code.ResourcesLoaders;
using UnityEngine;

namespace Code.Managers
{
    public class TAGameManager : MonoBehaviour
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

        public void Awake()
        {
            // Create the world watcher component. Doesn't need to be shown in Unity.
            _worldWatcher = gameObject.AddComponent<TAWorldWatcher>();
            
            TAEventManager.Shared().DidReadyWorldEvent.AddListener(WorldReady);
        }

        public void Start()
        {
            // This must be at Start, to let all the event listeners load in Awake() methods.
            worldManager.CreateWorld();
        }

        private static void WorldReady()
        {
            TAEventManager.Shared().PleaseStartGameEvent.Invoke(TAConfigurationLoader.GetConfiguration().numberOfOpponents + 1);
        }
    }
}
