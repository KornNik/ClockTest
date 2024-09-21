using Helpers.Extensions;
using Helpers.Observer;
using System;

namespace Behaviours
{
    sealed class SetupClock : IEventSubscription,
        IEventListener<ClockSetupEvent>, IEventListener<ClockSetupInputEvent>
    {
        private TimeSpan _newClockTime;
        private ClockInputType _alarmEnterType = default;

        public SetupClock()
        {
        }

        public void Subscribe()
        {
            this.EventStartListening<ClockSetupEvent>();
            this.EventStartListening<ClockSetupInputEvent>();
        }

        public void Unsubscribe()
        {
            this.EventStopListening<ClockSetupEvent>();
            this.EventStopListening<ClockSetupInputEvent>();
        }

        public void OnEventTrigger(ClockSetupEvent eventType)
        {
            //if (eventType.EventType == ClockSetupEventType.SetClock)
            //{
            //    _newClockTime = eventType.NewClockTime;
            //}
        }

        public void OnEventTrigger(ClockSetupInputEvent eventType)
        {
            //_alarmEnterType = eventType.EventType;
        }
    }
}
