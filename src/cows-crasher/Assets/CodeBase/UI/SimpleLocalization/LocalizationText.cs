using System.Linq;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.SimpleLocalization
{
    public class LocalizationText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private TextAsset _asset;
        [SerializeField] private int _id;

        private StoryItem[] _items;

        private void Awake() =>
            _items = new CsvAsset(_asset)
                .Rows()
                .Select(row => new StoryItem(row[1], row[2]))
                .Skip(1)
                .ToArray();

        private void Start() =>
            OnLocalizationChanged();

        private void OnEnable() =>
            Localization.Changed += OnLocalizationChanged;

        private void OnDisable() =>
            Localization.Changed -= OnLocalizationChanged;

        private void OnLocalizationChanged() =>
            _label.text = Localization.Current == Language.Russian
                ? _items[_id].Russian
                : _items[_id].English;
    }
}