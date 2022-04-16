using Code.Logic.Events;
using Code.Logic.Terrain;
using Code.ResourcesLoaders;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class TAUITerrainDataPanel : MonoBehaviour
    {
        public TextMeshProUGUI terrainTierText;
        public TextMeshProUGUI terrainSlotsText;
        public TextMeshProUGUI terrainTypeText;

        private void Awake()
        {
            gameObject.SetActive(false);
            TAEventManager.Shared().DidSelectTerrainEvent.AddListener(DidSelectTerrain);
            TAEventManager.Shared().DidUnselectTerrainEvent.AddListener(DidUnselectTerrain);
        }

        #region Event handling

        private void DidSelectTerrain(TATerrain terrain)
        {
            gameObject.SetActive(true);
            terrainTierText.text = TATextLoader.Tier + terrain.Tier;
            terrainSlotsText.text = TATextLoader.Slots + terrain.AvailableSlots;
            terrainTypeText.text = TATextLoader.Type + terrain.TileName;
        }

        private void DidUnselectTerrain()
        {
            gameObject.SetActive(false);
        }
        
        #endregion
    }
}
