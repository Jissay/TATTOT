using Code.Logic.Events;
using UnityEngine;

namespace Code.Managers
{
    public class TATurnManager : MonoBehaviour
    {
        private int _totalOpponents;
        
        private int _currentTurn;
        private int _currentOpponent;
        
        #region MonoBehaviour implementation

        public void Awake()
        {
            TAEventManager.Shared().PleaseStartGameEvent.AddListener(InitTurns);
        }

        #endregion

        #region Meta-turns logic

        private void InitTurns(int opponentsNumber)
        {
            Debug.Log("[ Initiating turns ... ]");
            
            _totalOpponents = opponentsNumber;
            _currentOpponent = 0;
            _currentTurn = 0;

            TAEventManager.Shared().DidStartGameEvent.Invoke();
            UpdateGameStatus();
        }

        private void UpdateGameStatus()
        {
            TAEventManager.Shared().PleaseUpdateActiveOpponentEvent.Invoke(_currentOpponent);
            TAEventManager.Shared().DidStartNewTurnEvent.Invoke(_currentTurn);
        }
        
        #endregion
    }
}