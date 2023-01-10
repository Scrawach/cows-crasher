using CodeBase.AI.Cow.States.Abstract;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.AI.Cow.States
{
    public class CowRunAwayState : State
    {
        [SerializeField] private Vector2 _safetyDistanceRange = new Vector2(8, 12);
        [SerializeField] private float _runAwaySpeed = 4f;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform Body;
        [SerializeField] private Transform EnemyBody;
        [SerializeField] private float _timeBeforeChangeDirection = 2f;
        
        [field: SerializeField] public override Transition[] Transitions { get; protected set; }

        private float _directionChangeCooldown = 2f;
        private float _safetyDistance;
        private float _previousSpeed;

        public bool InSafety { get; private set; }

        public override void Enter()
        {
            _directionChangeCooldown = _timeBeforeChangeDirection;
            _safetyDistance = Random.Range(_safetyDistanceRange.x, _safetyDistanceRange.y);
            _previousSpeed = _agent.speed;
            _agent.speed = _runAwaySpeed;
            InSafety = false;
            _agent.enabled = true;
        }

        public override void Exit()
        {
            _agent.speed = _previousSpeed;
            _agent.enabled = false;
        }

        public void Update()
        {
            var distanceToEnemy = DistanceToEnemy();

            if (distanceToEnemy.magnitude > _safetyDistance)
                InSafety = true;
            
            UpdateRunAwayDirection(distanceToEnemy);
        }

        private void UpdateRunAwayDirection(Vector3 distanceToEnemy)
        {
            UpdateCooldown();
            if (IsCooldownUp())
                return;
            _directionChangeCooldown = 0;
            RunAwayInSafety(distanceToEnemy);
        }

        private Vector3 DistanceToEnemy()
        {
            var distanceToEnemy = EnemyBody.position - Body.position;
            distanceToEnemy.y = 0;
            return distanceToEnemy;
        }

        private void UpdateCooldown() =>
            _directionChangeCooldown += Time.deltaTime;

        private bool IsCooldownUp() =>
            _directionChangeCooldown < _timeBeforeChangeDirection;

        private void RunAwayInSafety(Vector3 distanceToEnemy)
        {
            var runAway = -distanceToEnemy.normalized;
            var nextPoint = runAway * _safetyDistance + Body.position;
            _agent.destination = nextPoint;
        }
    }
}