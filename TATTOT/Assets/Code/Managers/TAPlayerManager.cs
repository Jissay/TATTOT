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
            TAEventManager.Shared().DidCreatePlayerInWorldEvent.AddListener(AddNewPlayer);
        }

        private void AddNewPlayer(TAOpponent opponent) { _opponent = opponent; }
    }
}