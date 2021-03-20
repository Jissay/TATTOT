using System.Collections.Generic;
using Code.Logic;
using Code.Logic.Events;

namespace Code.Managers
{
    public class TAOpponentsManager: TAAbstractManager<TAOpponentsManager>
    {
        private readonly List<TAOpponent> _opponents = new List<TAOpponent>();

        #region MonoBehaviour implementation

        private void Start()
        {
            TAEventManager.Shared().DidCreateOpponentEvent.AddListener(AddNewOpponent);
        }

        #endregion

        #region Opponents management

        private void AddNewOpponent(TAOpponent opponent) { _opponents.Add(opponent); }

        #endregion
    }
}