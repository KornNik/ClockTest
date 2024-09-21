using System;
using UnityEngine;
using Helpers.Extensions;
using DG.Tweening;

namespace GameUI
{
    abstract class ClockBase<T> : MonoBehaviour
    {
        [SerializeField] protected Transform _hoursHand;
        [SerializeField] protected Transform _minutesHand;
        [SerializeField] protected Transform _secondsHand;
        [SerializeField] protected T _timerText;

        protected virtual void SetClockHands(TimeSpan timerValue)
        {
            _hoursHand.DOLocalRotate(new Vector3(0f, 0f, (float)timerValue.TotalHours * -DateTimeExtension.DEGREES_IN_HOUR), 0.1f);
            _minutesHand.DOLocalRotate(new Vector3(0f, 0f, (float)timerValue.TotalMinutes * -DateTimeExtension.DEGREES_IN_MINUTE), 0.1f);
            _secondsHand.DOLocalRotate(new Vector3(0f, 0f, (float)timerValue.TotalSeconds * -DateTimeExtension.DEGREES_IN_SECOND), 0.1f);
        }
        protected abstract void FillText(TimeSpan timerValue);
    }
}
