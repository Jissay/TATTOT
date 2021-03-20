using Code.Logic;
using Code.Logic.Events;
using UnityEngine;

namespace Code.Managers
{
    public class TAPlayerManager : TAAbstractManager<TAPlayerManager>
    {
        /// <summary>
        /// <see cref="TAOpponent"/> that's controlled by the player. 
        /// </summary>
        private TAOpponent _opponent;

        private void Start()
        {
            TAEventManager.Shared().PleaseCreatePlayerInWorldEvent.AddListener(CreateNewPlayer);
        }

        private void CreateNewPlayer(Vector3Int newPosition)
        {
            // Set player data
            _opponent = new TAOpponent(true) { StartPosition = newPosition };

            // Broadcast player data creation
            TAEventManager.Shared().DidCreateOpponentEvent.Invoke(_opponent);
        }
    }
}