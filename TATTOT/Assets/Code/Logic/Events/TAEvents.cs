using Code.Logic;
using UnityEngine;
using UnityEngine.Events;

namespace Code.Events
{
    /// <summary>
    /// Naming conventions :
    /// - "Please" events are when a task is required (ex: PleaseCreatePlayer means a player object should be created).
    /// - "Did" events are when a task has been performed (ex: DidCreateOpponent means an opponent has been created).
    /// </summary>
    
    #region Opponent related events

    public class TADidCreateOpponentEvent: UnityEvent<TAOpponent> { }

    #endregion
    
    #region Player related events
    
    public class TAPleaseCreatePlayerInWorldEvent: UnityEvent<Vector3Int> { }

    #endregion
    
    #region World related events

    public class TADidGenerateWorldEvent: UnityEvent {}

    #endregion
    
}