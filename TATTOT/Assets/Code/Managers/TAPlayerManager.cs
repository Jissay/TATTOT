using Code.Logic;
using Code.Logic.Events;
using UnityEngine;

namespace Code.Managers
{
    public class TAPlayerManager : MonoBehaviour
    {
        /// <summary>
        /// <see cref="TAOpponent"/> that's controlled by the player. 
        /// </summary>
        private TAOpponent _opponent;

        public void Awake()
        {
            TAEventManager.Shared().DidCreatePlayerInWorldEvent.AddListener(AddNewPlayer);
        }

        private void AddNewPlayer(TAOpponent opponent) { _opponent = opponent; }
    }
}