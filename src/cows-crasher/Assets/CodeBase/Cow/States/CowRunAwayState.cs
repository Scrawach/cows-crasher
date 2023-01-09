using CodeBase.Cow.States.Abstract;
using CodeBase.Cow.Transitions;
using CodeBase.Logic;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Cow.States
{
    public class CowRunAwayState : State
    {
        [SerializeField] private float _safetyDistance = 10f;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform Body;
        [SerializeField] private Transform EnemyBody;
        [SerializeField] private float _timeBeforeChangeDirection = 2f;
        
        [field: SerializeField] public override Transition[] Transitions { get; protected set; }

        private float _directionChangeCooldown = 2f;

        public bool InSafety { get; private set; }

        public override void Enter()
        {
            _directionChangeCooldown = _timeBeforeChangeDirection;
            InSafety = false;
            _agent.enabled = true;
        }

        public override void Exit() =>
            _agent.enabled = false;

        public void Update()
        {
            UpdateCooldown();
            
            if (InSafety || IsCooldownUp())
                return;
            
            _directionChangeCooldown = 0;
            
            RunAwayInSafety();
        }

        private void UpdateCooldown() =>
            _directionChangeCooldown += Time.deltaTime;

        private bool IsCooldownUp() =>
            _directionChangeCooldown < _timeBeforeChangeDirection;

        private void RunAwayInSafety()
        {
            var selfPosition = Body.position;
            var distanceToEnemy = (EnemyBody.position - selfPosition);
            distanceToEnemy.y = 0;

            var runAway = -distanceToEnemy.normalized;
            var nextPoint = runAway * _safetyDistance + selfPosition;
            _agent.destination = nextPoint;

            if (distanceToEnemy.magnitude > _safetyDistance)
                InSafety = true;
        }
    }
}