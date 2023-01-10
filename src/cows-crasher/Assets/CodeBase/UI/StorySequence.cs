using System.Linq;
using UnityEngine;

namespace CodeBase.UI
{
    public class StorySequence
    {
        private readonly StoryItem[] _sequence;
        private int _current;

        public StorySequence(StoryItem[] sequence) =>
            _sequence = sequence;

        public bool HasNextItem() =>
            _current <= _sequence.Length - 1;

        public StoryItem Next()
        {
            var item = _sequence[_current];
            _current++;
            return item;
        }

        public static StorySequence FromAsset(TextAsset asset) =>
            new StorySequence
            (
                new CsvAsset(asset)
                    .Rows()
                    .Select(row => new StoryItem(row[1], row[2]))
                    .Skip(1)
                    .ToArray()
            );
    }
}