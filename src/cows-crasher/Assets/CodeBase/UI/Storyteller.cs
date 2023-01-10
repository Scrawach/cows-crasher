using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class Storyteller : MonoBehaviour
    {
        public TextAsset Story;
        public bool IsRussian;

        public GameObject StoryPanel;
        public Button NextButton;
        public TextMeshProUGUI Description;

        private StorySequence _storySequence;

        private void Awake()
        {
            _storySequence = StorySequence.FromAsset(Story);
            Show();
        }

        private void OnEnable() =>
            NextButton.onClick.AddListener(ShowStoryItem);

        private void OnDisable() =>
            NextButton.onClick.RemoveListener(ShowStoryItem);

        public void Show() =>
            ShowStoryItem();

        private void ShowStoryItem()
        {
            if (_storySequence.HasNextItem())
            {
                var story = _storySequence.Next();
                Description.text = IsRussian ? story.Russian : story.English;
            }
            else
            {
                StoryPanel.gameObject.SetActive(false);
            }
        }
    }
}