using Code.Logic.Events;
using Code.ResourcesLoaders;
using UnityEngine;

namespace Code.Logic.Watchers
{
    public class TAWorldWatcher : MonoBehaviour
    {
        private bool _playerCreated = false;
        private bool _allOpponentsCreated = false;
        private bool _worldCreated = false;

        private int _currentOpponentCount = 0;
        
        public TAWorldWatcher()
        {
            TAEventManager.Shared().DidCreateWorldEvent.AddListener(WorldCreated);
            TAEventManager.Shared().DidCreateOpponentInWorldEvent.AddListener(OpponentCreated);
        }

        private void CheckIfWorldReady()
        {
            if (_allOpponentsCreated && _worldCreated)
            {
                Debug.Log("[ World is ready ! ]");
                TAEventManager.Shared().DidReadyWorldEvent.Invoke();
                ClearWorldWatching();
            }
        }

        private void ClearWorldWatching()
        {
            _allOpponentsCreated = false;
            _worldCreated = false;
            _currentOpponentCount = 0;
        }
        
        private void OpponentCreated(TAOpponent opponent)
        {
            _currentOpponentCount += 1;
            
            // We had +1 to the total number of opponents as the player counts as an opponent in the game
            _allOpponentsCreated = _currentOpponentCount == TAConfigurationLoader.GetConfiguration().numberOfOpponents + 1;
            
            CheckIfWorldReady();
        }

        private void WorldCreated() { _worldCreated = true; }
    }
}