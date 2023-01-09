using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Logic
{
    public class AnimateAlongAgent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _agent;

        private void Update() =>
            _animator.SetFloat(Animations.Speed, _agent.velocity.magnitude);
    }
}