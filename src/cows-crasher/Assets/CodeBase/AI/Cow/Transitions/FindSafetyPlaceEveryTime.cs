using CodeBase.AI.Components;
using CodeBase.AI.Cow.Transitions.Abstract;
using CodeBase.Common;
using UnityEngine;

namespace CodeBase.AI.Cow.Transitions
{
    public class FindSafetyPlaceEveryTime : Transition
    {
        [SerializeField] private Timer _searchCooldown;
        [SerializeField] private FindSafetyPlace _findSafetyPlace;
        
        public override bool NeedTransit()
        {
            if (_searchCooldown.IsDone)
            {
                _searchCooldown.Erase();
                return _findSafetyPlace.HasSafetyPlaceNearby();
            }
            
            if (!_searchCooldown.IsPlaying) 
                _searchCooldown.Play();

            return false;
        }
    }
}