using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.Transitions
{
    public class IsNearToPoint : Transition
    {
        [SerializeField] private Transform _point;
        [SerializeField] private float _distance;
        
        public override bool NeedTransit()
        {
            var targetPosition = _point.transform.position;
            targetPosition.y = transform.position.y;
            var distance = Vector3.Distance(targetPosition, transform.position);
            return distance < _distance;
        }
    }
}