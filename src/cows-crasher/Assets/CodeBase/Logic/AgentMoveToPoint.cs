using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Logic
{
    public class AgentMoveToPoint : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform _point;

        private void Update()
        {
            if (_agent.enabled && TargetExist() && TargetNotReached()) 
                _agent.destination = _point.position;
        }

        private bool TargetExist() =>
            _point != null;

        private bool TargetNotReached() =>
            DistanceTo(_point.position) >= _agent.stoppingDistance;

        private float DistanceTo(Vector3 point)
        {
            var distance = point - _agent.transform.position;
            return Vector3.SqrMagnitude(distance);
        }
    }
}