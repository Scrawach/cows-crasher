using CodeBase.AI.Components;
using CodeBase.AI.Cow.States.Abstract;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.AI.Cow.States
{
    public class CowRunAwayState : State
    {
        [SerializeField] private float _runAwaySpeed = 4f;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform _body;
        [SerializeField] private EnemyFeeling _enemyFeeling;
        [SerializeField] private Mooing _mooing;
        [SerializeField] private ParticleSystem _runAwayVfx;
        
        private float _previousSpeed;

        public override void Enter()
        {
            _previousSpeed = _agent.speed;
            _agent.speed = _runAwaySpeed;
            _agent.enabled = true;
            _runAwayVfx.Play();
        }

        public override void Exit()
        {
            _agent.speed = _previousSpeed;
            _agent.enabled = false;
            _mooing.Forget();
            _runAwayVfx.Stop();
        }

        public void Update()
        {
            const float moveDistance = 3f;
            var distanceToEnemy = DistanceToEnemy();
            _agent.destination = transform.position - moveDistance * distanceToEnemy.normalized;
        }
        
        private Vector3 DistanceToEnemy()
        {
            var distanceToEnemy = _enemyFeeling.Enemy.position - _body.position;
            distanceToEnemy.y = 0;
            return distanceToEnemy;
        }
    }
}