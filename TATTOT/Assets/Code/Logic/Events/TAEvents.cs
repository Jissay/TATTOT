using UnityEngine;
using UnityEngine.Events;

namespace Code.Events
{
    #region Player related events
    
    public class TADidSetPlayerStartPositionEvent: UnityEvent<Vector3Int> { }

    #endregion

    #region World related events

    public class TADidGenerateWorldEvent: UnityEvent {}

    #endregion
    
}