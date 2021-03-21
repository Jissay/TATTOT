using UnityEngine;
using UnityEngine.Events;

namespace Code.Logic.Events
{
    /// <summary>
    /// Naming conventions :
    /// - "Please" events are when a task is required (ex: PleaseCreatePlayer means a player object should be created).
    /// - "Did" events are when a task has been performed (ex: DidCreateOpponent means an opponent has been created).
    /// </summary>
    
    #region Opponent related events

    public class TADidCreateOpponentInWorldEvent: UnityEvent<TAOpponent> { }
    public class TAPleaseCreateOpponentInWorldEvent: UnityEvent<Vector3Int> { }
    
    #endregion
    
    #region Player related events
    
    public class TADidCreatePlayerInWorldEvent: UnityEvent<TAOpponent> { }
    public class TAPleaseCreatePlayerInWorldEvent: UnityEvent<Vector3Int> { }

    #endregion
    
    #region World related events

    public class TADidGenerateWorldEvent: UnityEvent {}
    public class TADidAddNewStartPositionEvent: UnityEvent<Vector3Int> {}
    
    #endregion
    
}