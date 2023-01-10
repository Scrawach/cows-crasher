using CodeBase.AI.Components;
using CodeBase.AI.Cow.States.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.States
{
    public class CowStayInSafetySpace : State
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private Transform _body;
        [SerializeField] private FindSafetyPlace _safetyPlace;

        public override void Enter()
        {
            _body.forward = _safetyPlace.Nearby().SafePoint.forward;
            _timer.Play();
            _safetyPlace.Nearby().TakeSeat();
        }

        public override void Exit()
        {
            _timer.Erase();
            _safetyPlace.Nearby().FreeSeat();
        }
    }
}