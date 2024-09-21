namespace Helpers.Observer
{
    enum ClockInputType
    {
        None,
        Hands,
        Digits
    }
    struct ClockSetupInputEvent
    {
        private static ClockSetupInputEvent _inputEvent;

        private ClockInputType _eventType;

        public ClockInputType EventType => _eventType;

        public static void Trigger(ClockInputType eventType)
        {
            _inputEvent._eventType = eventType;
            EventManager.TriggerEvent(_inputEvent);
        }
    }
}
