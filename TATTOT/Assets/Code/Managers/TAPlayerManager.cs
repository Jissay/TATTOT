using System;
using Code.Events;
using Code.Model;
using UnityEngine;

namespace Code.Managers
{
    public class TAPlayerManager : TAAbstractManager<TAPlayerManager>
    {
        /// <summary>
        /// <see cref="TAOpponent"/> that's controlled by the player. 
        /// </summary>
        private readonly TAOpponent _opponent = new TAOpponent(true);

        private void Start()
        {
            TAEventManager.Shared().DidSetPlayerStartPositionEvent.AddListener(DidSetNewPlayerStartPosition);
        }

        private void DidSetNewPlayerStartPosition(Vector3Int newPosition)
        {
            _opponent.StartPosition = newPosition;
        }
    }
}