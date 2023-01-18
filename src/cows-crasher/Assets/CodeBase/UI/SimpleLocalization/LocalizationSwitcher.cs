using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SimpleLocalization
{
    public class LocalizationSwitcher : MonoBehaviour
    {
        [SerializeField] private Toggle _russianToggle;
        [SerializeField] private Toggle _englishToggle;
        
        private void OnEnable()
        {
            _russianToggle.onValueChanged.AddListener(OnRussianToggleChanged);
            _englishToggle.onValueChanged.AddListener(OnEnglishToggleChanged);
            Localization.Current = _russianToggle.isOn ? Language.Russian : Language.English;
        }
        
        private void OnDisable()
        {
            _russianToggle.onValueChanged.RemoveListener(OnRussianToggleChanged);
            _englishToggle.onValueChanged.RemoveListener(OnEnglishToggleChanged);
        }

        private void OnRussianToggleChanged(bool value)
        {
            if (value)
                Localization.Current = Language.Russian;
        }

        private void OnEnglishToggleChanged(bool value)
        {
            if (value)
                Localization.Current = Language.English;
        }
    }
}