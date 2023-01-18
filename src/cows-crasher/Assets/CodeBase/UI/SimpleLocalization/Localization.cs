using System;

namespace CodeBase.UI.SimpleLocalization
{
    public static class Localization
    {
        private static Language _current;
        
        public static Language Current 
        { 
            get => _current;
            set
            {
                _current = value;
                Changed?.Invoke();
            }
        }
        
        public static event Action Changed;
    }
}