using UnityEngine;

namespace CodeBase.Cow.Transitions
{
    public class WarningTransition : Transition
    {
        [SerializeField] private Mooing _mooing;
        
        public override bool NeedTransit()
        {
            var memory = _mooing.Heard;
            
            if (memory)
                _mooing.Forget();
            
            return memory;
        }
    }
}