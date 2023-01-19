using CodeBase.AI.Components;
using CodeBase.AI.Cow.States.Abstract;
using CodeBase.Common;
using UnityEngine;

namespace CodeBase.AI.Cow.States
{
    public class CowStayInSafetySpace : State
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private Transform _body;
        [SerializeField] private FindSafetyPlace _safetyPlace;
        [SerializeField] private Collider _collider;

        private SafetyPlace _safety;

        public override void Enter()
        {
            _safety = _safetyPlace.Nearby();
            _body.forward = _safety.SafePoint.forward;
            _body.transform.position = _safety.SafePoint.position;
            _timer.Play();
            _safety.TakeSeat();
            _collider.enabled = false;
        }

        public override void Exit()
        {
            _timer.Erase();
            _safety.FreeSeat();
            _collider.enabled = true;
        }
    }
}