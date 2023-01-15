using System;
using CodeBase.AI.Components;
using CodeBase.Common;
using JetBrains.Annotations;
using UnityEngine;

namespace CodeBase.Turrets
{
    public class CatapultAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Timer _cooldownTimer;

        private Action _onDone;
        
        public bool IsBusy { get; private set; }
        
        private void OnEnable() =>
            _animator.enabled = true;

        private void OnDisable() =>
            _animator.enabled = false;

        private void Start() =>
            _animator.SetFloat(Animations.Speed, 1 / _cooldownTimer.Target);

        private void Update() =>
            _animator.SetBool(Animations.Recharge, _cooldownTimer.IsPlaying);

        public void StartAttack(Action onDone)
        {
            if (IsBusy)
                throw new InvalidOperationException();
            
            _onDone = onDone;
            IsBusy = true;
            _animator.SetTrigger(Animations.Attack);
        }

        [UsedImplicitly]
        public void OnAttack()
        {
            _onDone?.Invoke();
            IsBusy = false;
            _onDone = null;
        }
    }
}