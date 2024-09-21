using System;

namespace Helpers.Observer
{
    struct SetupTimeEvent
    {
        private static SetupTimeEvent _setupTimeEvent;
        private TimeSpan _timeValue;

        public TimeSpan TimeValue => _timeValue;

        public static void Trigger(TimeSpan timerValue)
        {
            _setupTimeEvent._timeValue = timerValue;
            EventManager.TriggerEvent(_setupTimeEvent);
        }
    }
}
