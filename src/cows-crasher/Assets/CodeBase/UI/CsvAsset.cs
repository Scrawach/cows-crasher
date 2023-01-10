using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CodeBase.UI
{
    public class CsvAsset
    {
        private readonly TextAsset _textAsset;

        public CsvAsset(TextAsset textAsset) =>
            _textAsset = textAsset;

        public IEnumerable<string[]> Rows()
        {
            var rows = _textAsset.text.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var row in rows)
                yield return CsvLineFields(row);
        }

        private string[] CsvLineFields(string row)
        {
            const char fieldDelimiter = ',';
            const char shieldDelimiter = '\"';
            
            var fields = new List<string>();
            var field = new StringBuilder();
            var beenShielded = false;
            foreach (var symbol in row)
            {
                switch (symbol)
                {
                    case fieldDelimiter when !beenShielded:
                        fields.Add(field.ToString());
                        field = new StringBuilder();
                        break;
                    case shieldDelimiter:
                        beenShielded = !beenShielded;
                        break;
                    default:
                        field.Append(symbol);
                        break;
                }
            }

            fields.Add(field.ToString());
            return fields.ToArray();
        }
    }
}