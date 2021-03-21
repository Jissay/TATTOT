namespace Code.Logic.Events
{
    public class TAEventManager
    {
        #region Event storage

        public TADidAddNewStartPositionEvent DidAddNewStartPositionEvent { get; } = new TADidAddNewStartPositionEvent();
        public TADidCreateOpponentInWorldEvent DidCreateOpponentInWorldEvent { get; } = new TADidCreateOpponentInWorldEvent();
        public TADidCreatePlayerInWorldEvent DidCreatePlayerInWorldEvent { get; } = new TADidCreatePlayerInWorldEvent();

        public TAPleaseCreateOpponentInWorldEvent PleaseCreateOpponentInWorldEvent { get; } =
            new TAPleaseCreateOpponentInWorldEvent();
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