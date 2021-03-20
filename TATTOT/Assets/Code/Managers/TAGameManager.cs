using Code.Events;
using UnityEngine;

namespace Code.Managers
{
    public class TAGameManager : TAAbstractManager<TAGameManager>
    {
        void Start()
        {
            // Triggers a world creation
            TAEventManager.Shared().CreateWorldEvent.Invoke();
        }
    }
}
