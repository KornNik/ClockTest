using Helpers.Extensions;
using Helpers.Observer;
using System;
using TMPro;

namespace GameUI
{
    internal sealed class SetupClockUI : ClockBase<TMP_InputField>, IEventListener<SetupTimeEvent>,
        IEventListener<ClockSetupEvent>, IEventListener<ClockSetupInputEvent>
    {
        private ClockInputType _alarmEnterType = default;

        private void Awake()
        {
        }

        private void OnEnable()
        {
            this.EventStartListening<SetupTimeEvent>();
            this.EventStartListening<ClockSetupEvent>();
            this.EventStartListening<ClockSetupInputEvent>();
        }

        private void OnDisable()
        {
            this.EventStopListening<SetupTimeEvent>();
            this.EventStopListening<ClockSetupEvent>();
            this.EventStopListening<ClockSetupInputEvent>();
        }

        protected override void FillText(TimeSpan timerValue)
        {
            var valueConverted = DateTimeExtension.FromDoubleToString(timerValue.TotalSeconds);
            _timerText.text = valueConverted;
        }

        private void SyncAlarmWithClockTime(TimeSpan time)
        {
            SetClockHands(time);
            FillText(time);
        }

        private void SetAlarm(ClockInputType alarmEnterType)
        {
            switch (alarmEnterType)
            {
                case ClockInputType.Hands:
                    ClockSetupEvent.Trigger(ClockSetupEventType.SetClock, DateTimeExtension.HandsDegreesInTime
                        (_hoursHand.localRotation.eulerAngles, _minutesHand.localRotation.eulerAngles,
                        _secondsHand.localRotation.eulerAngles));
                    break;
                case ClockInputType.Digits:
                    ClockSetupEvent.Trigger(ClockSetupEventType.SetClock, DateTimeExtension.EnterStringInTime(_timerText.text));
                    break;
                default:
                    break;
            }
        }

        public void OnEventTrigger(SetupTimeEvent eventType)
        {
            SyncAlarmWithClockTime(eventType.TimeValue);
        }
        public void OnEventTrigger(ClockSetupEvent eventType)
        {
            if (eventType.EventType == ClockSetupEventType.ButtonDown)
            {
                SetAlarm(_alarmEnterType);
            }
        }
        public void OnEventTrigger(ClockSetupInputEvent eventType)
        {
            _alarmEnterType = eventType.EventType;
        }
    }
}