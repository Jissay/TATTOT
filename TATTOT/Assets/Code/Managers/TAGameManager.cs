using Code.GameObjects;

namespace Code.Managers
{
    public class TAGameManager : TAAbstractManager<TAGameManager>
    {
        /// <summary>
        /// <see cref="TAWorldManager"/> set in Unity UI. This keep tracks of the world's events
        /// and data. Handles the displayed <see cref="TAWorldMap"/>
        /// </summary>
        public TAWorldManager worldManager;

        public TAOpponentsManager opponentsManager;

        private void Start()
        {
            worldManager.CreateWorld();
        }
    }
}
