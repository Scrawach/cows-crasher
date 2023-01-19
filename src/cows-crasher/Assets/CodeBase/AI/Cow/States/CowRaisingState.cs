using CodeBase.AI.Cow.States.Abstract;
using CodeBase.Common;
using UnityEngine;

namespace CodeBase.AI.Cow.States
{
    public class CowRaisingState : State
    {
        [SerializeField] private Transform Body;
        [SerializeField] private Timer _risingTime;

        private Quaternion _startRotation;
        private Quaternion _desiredRotation;

        public override void Enter()
        {
            Body.position = DesiredPosition();
            _startRotation = Body.rotation;
            _desiredRotation = Quaternion.Euler(DesiredEulerAngles());
            _risingTime.Play();
        }

        public override void Exit() { }

        public void Update() =>
            Body.transform.rotation = Quaternion.Slerp(_startRotation, _desiredRotation, _risingTime.Progress);

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