using CodeBase.AI.Components;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.Transitions
{
    public class HasSafetyPlaceNearby : Transition
    {
        [SerializeField] private FindSafetyPlace _findSafetyPlace;
        [SerializeField] private int _radius;
        
        public override bool NeedTransit() =>
            _findSafetyPlace.HasSafetyPlaceNearby(_radius);
    }
}