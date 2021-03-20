using Code.Events;

namespace Code.Logic.Events
{
    public class TAEventManager
    {
        #region Event storage

        public TADidCreateOpponentEvent DidCreateOpponentEvent { get; } = new TADidCreateOpponentEvent(); 
        public TAPleaseCreatePlayerInWorldEvent PleaseCreatePlayerInWorldEvent { get; } = new TAPleaseCreatePlayerInWorldEvent();
        
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