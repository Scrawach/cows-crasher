using System;
using CodeBase.UI.SimpleLocalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class StoryPanel : MonoBehaviour
    {
        [SerializeField] private Button _next;
        [SerializeField] private TextMeshProUGUI _description;

        private Action _onAccepted;
        private StoryItem _current;
        
        private void OnEnable()
        {
            _next.onClick.AddListener(OnNextClicked);
            Localization.Changed += OnLocalizationChanged;
        }

        private void OnDisable()
        {
            _next.onClick.RemoveListener(OnNextClicked);
            Localization.Changed -= OnLocalizationChanged;
        }

        private void OnLocalizationChanged() =>
            ShowCurrentItem();

        private string ShowCurrentItem() =>
            _description.text = Localization.Current == Language.Russian 
                ? _current.Russian 
                : _current.English;

        public void Show(StoryItem item, Action onAccepted = null)
        {
            _current = item;
            _onAccepted = onAccepted;
            ShowCurrentItem();
            gameObject.SetActive(true);
        }

        public void Hide() =>
            gameObject.SetActive(false);

        private void OnNextClicked() =>
            _onAccepted?.Invoke();
    }
}