using CodeBase.AI.Cow.States.Abstract;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.States
{
    public class CowRaisingState : State
    {
        [SerializeField] private Transform Body;
        [SerializeField] private float _risingTime = 0.5f;

        private Quaternion _startRotation;
        private Quaternion _desiredRotation;

        private float _elapsed;
        
        public bool IsRaised { get; private set; }
        

        public override void Enter()
        {
            IsRaised = false;
            _elapsed = 0;
            Body.position = DesiredPosition();
            _startRotation = Body.rotation;
            _desiredRotation = Quaternion.Euler(DesiredEulerAngles());
        }

        public override void Exit() { }

        public void Update()
        {
            if (IsRaised)
                return;
            
            _elapsed += Time.deltaTime;
            
            var lerpProgress = _elapsed / _risingTime;
            Body.transform.rotation = Quaternion.Slerp(_startRotation, _desiredRotation, lerpProgress);

            if (_elapsed >= _risingTime) 
                IsRaised = true;
        }
        
        private Vector3 DesiredPosition()
        {
            var position = Body.position;
            position.y = 0.05f;
            return position;
        }

        private Vector3 DesiredEulerAngles()
        {
            var angles = Body.eulerAngles;
            return new Vector3(0, angles.y, 0);
        }
    }
}