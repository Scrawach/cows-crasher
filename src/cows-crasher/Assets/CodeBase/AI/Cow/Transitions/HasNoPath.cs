using CodeBase.AI.Components;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.AI.Cow.Transitions
{
    public class HasNoPath : Transition
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _distance = 0.25f;
        [SerializeField] private FindSafetyPlace _safetyPlace;
        
        public override bool NeedTransit()
        {
            var target = _safetyPlace.Nearby().SafePoint.position;
            target.y = transform.position.y;
            var distance = Vector3.Distance(target, transform.position);
            return distance <= _distance;
        }
    }
}