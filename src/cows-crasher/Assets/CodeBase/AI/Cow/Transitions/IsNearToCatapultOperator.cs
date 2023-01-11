using CodeBase.AI.Cow.Transitions.Abstract;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.AI.Cow.Transitions
{
    public class IsNearToCatapultOperator : Transition
    {
        [SerializeField] private CatapultOperator _catapultOperator;
        [SerializeField] private float _distance;
        
        public override bool NeedTransit()
        {
            var targetPosition = _catapultOperator.transform.position;
            targetPosition.y = transform.position.y;
            var distance = Vector3.Distance(targetPosition, transform.position);
            return distance < _distance;
        }
    }
}