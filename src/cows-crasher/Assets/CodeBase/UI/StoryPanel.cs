using System;
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
        
        private void OnEnable() =>
            _next.onClick.AddListener(OnNextClicked);

        private void OnDisable() =>
            _next.onClick.RemoveListener(OnNextClicked);

        public void Show(string story, Action onAccepted = null)
        {
            _onAccepted = onAccepted;
            _description.text = story;
            gameObject.SetActive(true);
        }

        public void Hide() =>
            gameObject.SetActive(false);

        private void OnNextClicked() =>
            _onAccepted?.Invoke();
    }
}