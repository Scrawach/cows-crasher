using CodeBase.AI.Components;
using UnityEngine;

namespace CodeBase.Turrets
{
    public class RechargeAnimationSpeed : MonoBehaviour
    {
        private static readonly int SpeedHash = Animator.StringToHash("Speed");
        
        [SerializeField] private Animator _animator;
        [SerializeField] private Timer _cooldownTimer;
        
        private void Start() =>
            _animator.SetFloat(SpeedHash, 1 / _cooldownTimer.Target);
    }
}