using CodeBase.AI.Cow.States.Abstract;
using CodeBase.Logic;
using CodeBase.Logic.Turrets;
using UnityEngine;

namespace CodeBase.AI.Cow.States
{
    public class CowStayInCatapult : State
    {
        [SerializeField] private Transform _body;
        [SerializeField] private CatapultOperator _catapultOperator;
        
        public override void Enter()
        {
            _body.forward = (_catapultOperator.transform.position - _body.transform.position).normalized;
            _catapultOperator.Activate();
        }

        public override void Exit() =>
            _catapultOperator.Deactivate();
    }
}