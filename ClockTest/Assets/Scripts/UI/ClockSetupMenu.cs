using UnityEngine;
using UnityEngine.UI;
using Helpers.Observer;

namespace GameUI
{
    class ClockSetupMenu : BaseUI
    {
        [SerializeField] private Button _clockButton;
        [SerializeField] private Button _setClockButton;
        [SerializeField] private SetupClockUI _alarmClock;

        private void OnEnable()
        {
            _clockButton.onClick.AddListener(OnClockButtonDown);
            _setClockButton.onClick.AddListener(OnSetClockButtonDown);
        }

        private void OnDisable()
        {
            _clockButton.onClick.RemoveListener(OnClockButtonDown);
            _setClockButton.onClick.RemoveListener(OnSetClockButtonDown);
        }
        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();
        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }

        private void OnClockButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.ClockMenu);
        }
        private void OnSetClockButtonDown()
        {
            ClockSetupEvent.Trigger(ClockSetupEventType.ButtonDown);
        }
    }
}