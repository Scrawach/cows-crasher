using CodeBase.LevelManagement;
using CodeBase.Logic;
using CodeBase.Ufo;
using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private UfoCollector _collector;
        [SerializeField] private LevelData _level;

        private void Start() =>
            OnScoreChanged();

        private void OnEnable() =>
            _collector.Changed += OnScoreChanged;

        private void OnDisable() =>
            _collector.Changed -= OnScoreChanged;

        private void OnScoreChanged() =>
            _label.text = $"{_collector.Count} / {_level.GoalScore}";
    }
}