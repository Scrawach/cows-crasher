using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SimpleLocalization
{
    public class LocalizationSwitcher : MonoBehaviour
    {
        [SerializeField] private Toggle _russianToggle;
        [SerializeField] private Toggle _englishToggle;

        private void Start()
        {
            if (Localization.Current == Language.English)
            {
                _englishToggle.isOn = true;
                OnEnglishToggleChanged(true);
            }
            else
            {
                _russianToggle.isOn = true;
                OnRussianToggleChanged(true);
            }
        }

        private void OnEnable()
        {
            _russianToggle.onValueChanged.AddListener(OnRussianToggleChanged);
            _englishToggle.onValueChanged.AddListener(OnEnglishToggleChanged);
        }
        
        private void OnDisable()
        {
            _russianToggle.onValueChanged.RemoveListener(OnRussianToggleChanged);
            _englishToggle.onValueChanged.RemoveListener(OnEnglishToggleChanged);
        }

        private static void OnRussianToggleChanged(bool isOn)
        {
            if (isOn) Localization.Current = Language.Russian;
        }

        private static void OnEnglishToggleChanged(bool isOn)
        {
            if (isOn) Localization.Current = Language.English;
        }
    }
}