using CodeBase.Cow.States.Abstract;
using CodeBase.Cow.Transitions;
using UnityEngine;

namespace CodeBase.Cow.States
{
    public class CowLevitationState : State
    {
        [SerializeField] private Rigidbody _rigidbody;
        [field: SerializeField] public override Transition[] Transitions { get; protected set; }

        public override void Enter() =>
            _rigidbody.isKinematic = false;
        
        public override void Exit() =>
            _rigidbody.isKinematic = true;
    }
}