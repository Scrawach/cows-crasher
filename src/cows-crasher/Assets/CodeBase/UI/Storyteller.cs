using System;
using UnityEngine;

namespace CodeBase.UI
{
    public class Storyteller : MonoBehaviour
    {
        [SerializeField] private TextAsset _storyText;
        [SerializeField] public StoryPanel _storyPanel;

        private StorySequence _storySequence;
        private Action _onEnded;

        private void Awake() =>
            _storySequence = StorySequence.FromAsset(_storyText);
        
        public void Show(Action onEnded = null)
        {
            _onEnded = onEnded;
            ShowStoryItem();
        }

        private void ShowStoryItem()
        {
            if (_storySequence.HasNextItem())
            {
                var story = _storySequence.Next();
                _storyPanel.Show(story.Russian, ShowStoryItem);
            }
            else
            {
                _storyPanel.Hide();
                _onEnded?.Invoke();
            }
        }
    }
}