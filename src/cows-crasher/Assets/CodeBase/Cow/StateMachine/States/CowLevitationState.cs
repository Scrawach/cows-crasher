using CodeBase.Cow.StateMachine.States.Abstract;
using UnityEngine;

namespace CodeBase.Cow.StateMachine.States
{
    public class CowLevitationState : IState, IUpdatableState
    {
        private readonly CowStateMachine _stateMachine;
        private readonly CowBehaviour _cowBehaviour;

        public CowLevitationState(CowStateMachine stateMachine, CowBehaviour cowBehaviour)
        {
            _stateMachine = stateMachine;
            _cowBehaviour = cowBehaviour;
        }

        public void Enter() =>
            _cowBehaviour.Rigidbody.isKinematic = false;

        public void Update(float delta)
        {
            if (!_cowBehaviour.attractedBody.IsAttracting && _cowBehaviour.IsGrounded) 
                _stateMachine.Enter<CowRaisingState>();
        }

        public void Exit() =>
            _cowBehaviour.Rigidbody.isKinematic = true;

        private void DisablePhysics()
        {
            _cowBehaviour.Rigidbody.isKinematic = true;
            _cowBehaviour.Rigidbody.velocity = Vector3.zero;
            _cowBehaviour.Rigidbody.angularVelocity = Vector3.zero;
        }

    }
}