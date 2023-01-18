using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.AI.Components
{
    public class AgentMoveToPoint : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private Vector3 _target;
        private bool _hasTarget;
        
        private void Update()
        {
            if (_hasTarget && TargetNotReached()) 
                _agent.destination = _target;
        }

        public void MoveTo(Vector3 point)
        {
            _target = point;
            _hasTarget = true;
        }

        public void ResetMovement() =>
            _hasTarget = false;

        public bool TargetNotReached() =>
            DistanceTo(_target) >= _agent.stoppingDistance;

        private float DistanceTo(Vector3 point)
        {
            var distance = point - _agent.transform.position;
            return Vector3.SqrMagnitude(distance);
        }
    }
}