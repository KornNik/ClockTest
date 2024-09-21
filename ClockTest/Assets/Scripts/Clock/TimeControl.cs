using UnityEngine;
using Behaviours;

namespace Controllers
{
    sealed class TimeControl : MonoBehaviour
    {
        private ClockTime _clockTime;
        private SetupClock _alarmClock;

        public ClockTime ClockTime => _clockTime;
        public SetupClock AlarmClock => _alarmClock;

        private void Awake()
        {
            _clockTime = new ClockTime();
            _alarmClock = new SetupClock();
        }
        private void Start()
        {
            _clockTime.RequestTime();
        }
        private void OnEnable()
        {
            _clockTime.Subscribe();
            _alarmClock.Subscribe();
        }
        private void OnDisable()
        {
            _clockTime.Unsubscribe();
            _alarmClock.Unsubscribe();
        }
    }
}
