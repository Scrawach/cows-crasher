using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.AI.Components
{
    public class AnimateAlongAgent : MonoBehaviour
    {
        private static readonly int SpeedHash = Animator.StringToHash("Speed");
        
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _agent;

        private void Update() =>
            _animator.SetFloat(SpeedHash, _agent.velocity.magnitude);
    }
}