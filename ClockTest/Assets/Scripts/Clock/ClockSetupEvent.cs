using System;

namespace Helpers.Observer
{
    enum ClockSetupEventType
    {
        None,
        SetClock,
        ButtonDown
    }
    struct ClockSetupEvent
    {
        private static ClockSetupEvent _alarmEvent;

        private ClockSetupEventType _eventType;
        private TimeSpan _newClockTime;

        public ClockSetupEventType EventType => _eventType;
        public TimeSpan NewClockTime => _newClockTime;

        public static void Trigger(ClockSetupEventType eventType, TimeSpan alarmTime = default)
        {
            _alarmEvent._eventType = eventType;
            _alarmEvent._newClockTime = alarmTime;
            EventManager.TriggerEvent(_alarmEvent);
        }
    }
}
