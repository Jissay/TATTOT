namespace Code.Logic.Events
{
    public class TAEventManager
    {
        #region Event storage

        public TADidAddNewStartPositionEvent DidAddNewStartPositionEvent { get; } = new TADidAddNewStartPositionEvent();
        public TADidCreateOpponentInWorldEvent DidCreateOpponentInWorldEvent { get; } = new TADidCreateOpponentInWorldEvent();
        public TADidCreatePlayerInWorldEvent DidCreatePlayerInWorldEvent { get; } = new TADidCreatePlayerInWorldEvent();
        public TADidCreateWorldEvent DidCreateWorldEvent { get; } = new TADidCreateWorldEvent();
        public TADidStartGameEvent DidStartGameEvent { get; } = new TADidStartGameEvent();
        public TADidReadyWorldEvent DidReadyWorldEvent { get; } = new TADidReadyWorldEvent();
        
        public TAPleaseCreateOpponentInWorldEvent PleaseCreateOpponentInWorldEvent { get; } =
            new TAPleaseCreateOpponentInWorldEvent();
        public TAPleaseCreatePlayerInWorldEvent PleaseCreatePlayerInWorldEvent { get; } = new TAPleaseCreatePlayerInWorldEvent();
        public TAPleaseCreateWorldEvent PleaseCreateWorldEvent { get; } = new TAPleaseCreateWorldEvent();
        public TAPleaseStartGameEvent PleaseStartGameEvent { get; } = new TAPleaseStartGameEvent();

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