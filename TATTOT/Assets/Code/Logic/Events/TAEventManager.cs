namespace Code.Events
{
    public class TAEventManager
    {
        #region Event storage

        public TADidSetPlayerStartPositionEvent DidSetPlayerStartPositionEvent { get; } = new TADidSetPlayerStartPositionEvent();
        
        #endregion
        
        #region Singleton handling

        private static TAEventManager _shared;

        private TAEventManager() { }

        public static TAEventManager Shared()
        {
            return _shared ??= new TAEventManager();
        }

        #endregion
    }
}