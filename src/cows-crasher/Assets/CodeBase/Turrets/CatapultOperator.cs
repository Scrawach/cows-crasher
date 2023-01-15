using System;
using CodeBase.AI.Components;
using UnityEngine;

namespace CodeBase.Turrets
{
    public class CatapultOperator : MonoBehaviour
    {
        [SerializeField] private Catapult _catapult;
        [SerializeField] private CatapultAnimator _animator;
        [SerializeField] private RotateToTarget _rotateToTarget;
        [SerializeField] private Collider _observerCollider;
        [SerializeField] private Timer _cooldownTimer;

        public void Activate()
        {
            _observerCollider.enabled = true;
            _catapult.enabled = true;
            _rotateToTarget.enabled = true;
            _animator.enabled = true;
            _cooldownTimer.Start();
        }

        public void Deactivate()
        {
            _catapult.enabled = false;
            _rotateToTarget.enabled = false;
            _observerCollider.enabled = false;
            _animator.enabled = false;
            _cooldownTimer.Stop();
        }
    }
}