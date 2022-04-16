using Code.Logic.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class TAUIDevToolsPanel : MonoBehaviour
    {
        public Button reloadMapButton;

        // Start is called before the first frame update
        private void Start()
        {
            reloadMapButton.onClick = TAEventManager.Shared().PleaseCreateWorldEvent;
        }
    }
}
