using System.Collections.Generic;
using Code.Logic;
using Code.Logic.Events;
using UnityEngine;

namespace Code.Managers
{
    public class TAOpponentsManager: TAAbstractManager<TAOpponentsManager>
    {
        private readonly List<TAOpponent> _opponents = new List<TAOpponent>();

        #region MonoBehaviour implementation

        private void Awake()
        {
            TAEventManager.Shared().DidCreateOpponentInWorldEvent.AddListener(AddNewOpponent);
            TAEventManager.Shared().PleaseCreateOpponentInWorldEvent.AddListener(CreateNewOpponentWrapper);
            TAEventManager.Shared().PleaseCreatePlayerInWorldEvent.AddListener(CreateNewPlayerWrapper);
        }

        #endregion

        #region Opponents management

        private static void CreateNewOpponent(Vector3Int position, bool isPlayer)
        {
            var opponent = new TAOpponent(isPlayer) { StartPosition = position};
            
            // Broadcast player data creation
            TAEventManager.Shared().DidCreateOpponentInWorldEvent.Invoke(opponent);
        }
        
        private static void CreateNewPlayerWrapper(Vector3Int position)
        {
            CreateNewOpponent(position, true);
        }
        
        private static void CreateNewOpponentWrapper(Vector3Int position) { CreateNewOpponent(position, false); }
        
        private void AddNewOpponent(TAOpponent opponent) { _opponents.Add(opponent); }

        #endregion
    }
}