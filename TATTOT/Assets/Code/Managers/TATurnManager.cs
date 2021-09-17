using Code.Logic.Events;
using UnityEngine;

namespace Code.Managers
{
    public class TATurnManager : MonoBehaviour
    {
        private int totalOpponents;
        
        private int currentTurn;
        private int currentOpponent;
        
        #region MonoBehaviour implementation

        private void Awake()
        {
            TAEventManager.Shared().PleaseStartGameEvent.AddListener(InitTurns);
        }

        #endregion

        #region Meta-turns logic

        private void InitTurns(int opponentsNumber)
        {
            Debug.Log("Initiating turns ...");
            
            totalOpponents = opponentsNumber + 1;
            currentOpponent = 0;
            currentTurn = 0;

            TAEventManager.Shared().DidStartGameEvent.Invoke();
            UpdateGameStatus();
        }

        private void UpdateGameStatus()
        {
            //TAEventManager.Shared().DidUpdateActiveOpponent.Invoke(currentOpponent);
            //TAEventManager.Shared().DidStartNewTurn.Invoke(currentTurn);
        }
        
        #endregion
    }
}