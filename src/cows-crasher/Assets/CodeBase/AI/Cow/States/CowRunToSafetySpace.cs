using CodeBase.AI.Components;
using CodeBase.AI.Cow.States.Abstract;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.AI.Cow.States
{
    public class CowRunToSafetySpace : State
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private FindSafetyPlace _findSafetyPlace;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Mooing _mooing;
        [SerializeField] private ParticleSystem _runAwayVfx;

        private SafetyPlace _safetyPlace;
        private float _previousSpeed;

        public override void Enter()
        {
            _agent.enabled = true;
            _safetyPlace = _findSafetyPlace.Nearby();
            _previousSpeed = _agent.speed;
            _agent.speed = _speed;
            _agent.destination = _safetyPlace.SafePoint.position;
            _safetyPlace.TakeSeat();
            _runAwayVfx.Play();
        }

        public override void Exit()
        {
            _agent.speed = _previousSpeed;
            _agent.enabled = false;
            _safetyPlace.FreeSeat();
            _mooing.Forget();
            _runAwayVfx.Stop();
        }
    }
}