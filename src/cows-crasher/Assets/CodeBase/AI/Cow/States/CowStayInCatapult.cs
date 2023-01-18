using CodeBase.AI.Cow.States.Abstract;
using CodeBase.Turrets;
using UnityEngine;

namespace CodeBase.AI.Cow.States
{
    public class CowStayInCatapult : State
    {
        [SerializeField] private Transform _target;
        [SerializeField] private CatapultOperator _catapultOperator;
        
        public override void Enter()
        {
            var cow = _catapultOperator.transform;
            cow.forward = (_target.transform.position - cow.position).normalized;
            _catapultOperator.Activate();
        }

        public override void Exit() =>
            _catapultOperator.Deactivate();
    }
}