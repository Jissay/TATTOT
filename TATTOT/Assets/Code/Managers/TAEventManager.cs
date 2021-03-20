namespace Code.Events
{
    public class TAEventManager
    {
        #region Event storage

        public TACreateWorldEvent CreateWorldEvent { get; } = new TACreateWorldEvent();

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