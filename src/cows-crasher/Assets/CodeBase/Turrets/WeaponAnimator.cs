using System;
using JetBrains.Annotations;
using UnityEngine;

namespace CodeBase.Turrets
{
    public class WeaponAnimator : MonoBehaviour
    {
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        
        [SerializeField] private Animator _animator;
        
        private Action _onEnded;
        
        public void PlayAttack(Action onEnded = null)
        {
            if (_onEnded != null)
                throw new InvalidOperationException("Previous animation not completed!");
            
            _animator.SetTrigger(AttackHash);
            _onEnded = onEnded;
        }

        [UsedImplicitly]
        public void OnAttack()
        {
            _onEnded?.Invoke();
            _onEnded = null;
        }
    }
}