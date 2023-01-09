using CodeBase.Cow.StateMachine.States.Abstract;
using UnityEngine;

namespace CodeBase.Cow.StateMachine.States
{
    public class CowRaisingState : IState, IUpdatableState
    {
        private readonly CowStateMachine _stateMachine;
        private readonly CowBehaviour _cowBehaviour;
        
        private Quaternion _startRotation;
        private Quaternion _desiredRotation;

        private float _elapsed;
        
        private const float RisingTime = 0.5f;
        
        public CowRaisingState(CowStateMachine stateMachine, CowBehaviour cowBehaviour)
        {
            _stateMachine = stateMachine;
            _cowBehaviour = cowBehaviour;
        }
        
        public void Enter()
        {
            var cow = _cowBehaviour.transform;
            
            _elapsed = 0;
            
            cow.position = DesiredPosition();
            _startRotation = cow.rotation;
            _desiredRotation = Quaternion.Euler(DesiredEulerAngles());
        }

        public void Exit() { }

        public void Update(float delta)
        {
            _elapsed += delta;
            
            var lerpProgress = _elapsed / RisingTime;
            _cowBehaviour.transform.rotation = Quaternion.Slerp(_startRotation, _desiredRotation, lerpProgress);
            
            if (_cowBehaviour.AttractedObject.IsAttracting)
                _stateMachine.Enter<CowLevitationState>();

            if (_elapsed >= RisingTime)
                _stateMachine.Enter<CowNavigationState>();
        }
        
        private Vector3 DesiredPosition()
        {
            var transform = _cowBehaviour.transform;
            var position = transform.position;
            position.y = 0.05f;
            return position;
        }

        private Vector3 DesiredEulerAngles()
        {
            var transform = _cowBehaviour.transform;
            var angles = transform.eulerAngles;
            return new Vector3(0, angles.y, 0);
        }
    }
}