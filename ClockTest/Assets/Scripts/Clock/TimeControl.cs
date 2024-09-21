using UnityEngine;
using Behaviours;
using System.Collections.Generic;

namespace Controllers
{
    sealed class TimeControl : MonoBehaviour
    {
        private ClockTime _clockTime;

        public ClockTime ClockTime => _clockTime;

        private List<IEventSubscription> _eventSubscriptions;

        private void Awake()
        {
            _clockTime = new ClockTime();

            CreateSubscriptionList();
        }
        private void Start()
        {
            _clockTime.RequestTime();
        }
        private void OnEnable()
        {
            foreach (var subscription in _eventSubscriptions)
            {
                subscription.Subscribe();
            }
        }
        private void OnDisable()
        {
            foreach (var subscription in _eventSubscriptions)
            {
                subscription.Unsubscribe();
            }
        }

        private void CreateSubscriptionList()
        {
            _eventSubscriptions = new List<IEventSubscription>(4);
            _eventSubscriptions.Add(_clockTime);
        }
    }
}
