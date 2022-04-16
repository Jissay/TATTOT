using Code.Logic.Terrain;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Code.Logic.Events
{
    /// <summary>
    /// Naming conventions :
    /// - "Please" events are when a task is required (ex: PleaseCreatePlayer means a player object should be created).
    /// - "Did" events are when a task has been performed (ex: DidCreateOpponent means an opponent has been created).
    /// </summary>

    #region Game related events

    public class TADidStartGameEvent: UnityEvent {}
    /// <summary>
    /// Parameter int is the number of opponents in the game.
    /// </summary>
    public class TAPleaseStartGameEvent: UnityEvent<int> {}

    #endregion
    
    #region Opponent related events

    /// <summary>
    /// Parameter <see cref="TAOpponent"/> is the opponent created.
    /// </summary>
    public class TADidCreateOpponentInWorldEvent: UnityEvent<TAOpponent> { }
    /// <summary>
    /// Parameter <see cref="TAOpponent"/> is the opponent to create.
    /// </summary>
    public class TAPleaseCreateOpponentInWorldEvent: UnityEvent<Vector3Int> { }
    
    #endregion
    
    #region Player related events
    
    public class TADidCreatePlayerInWorldEvent: UnityEvent<TAOpponent> { }
    public class TAPleaseCreatePlayerInWorldEvent: UnityEvent<Vector3Int> { }

    #endregion

    #region Turn related events

    public class TADidStartNewTurnEvent: UnityEvent<int> { }
    public class TAPleaseUpdateActiveOpponentEvent: UnityEvent<int> { }

    #endregion

    #region UI related events

    public class TADidSelectTerrainEvent: UnityEvent<TATerrain> { }

    public class TADidUnselectTerrainEvent: UnityEvent { }
    
    #endregion
    
    #region World related events

    public class TADidCreateWorldEvent: UnityEvent {}
    public class TAPleaseCreateWorldEvent: Button.ButtonClickedEvent {} // This is a ButtonClickedEvent as it is used in dev tools
    public class TADidAddNewStartPositionEvent: UnityEvent<Vector3Int> {}
    public class TADidReadyWorldEvent: UnityEvent {}
    
    #endregion
    
}