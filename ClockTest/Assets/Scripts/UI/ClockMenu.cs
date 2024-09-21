using Helpers;
using Helpers.Observer;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    class ClockMenu : BaseUI
    {
        [SerializeField] private Button _setupMenuButton;
        [SerializeField] private TimeUI _timeUI;

        private void OnEnable()
        {
            _setupMenuButton.onClick.AddListener(OnSetupMenuButtonDown);
        }

        private void OnDisable()
        {
            _setupMenuButton.onClick.RemoveListener(OnSetupMenuButtonDown);
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

        private void OnSetupMenuButtonDown()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.AlarmMenu);
            SetupTimeEvent.Trigger(Services.Instance.TimeController.ServicesObject.ClockTime.GetCurrentTime());
        }
    }
}