using CodeBase.Common;
using UnityEngine;

namespace CodeBase.Turrets
{
    public class AttackWithCooldown : TargetHandler
    {
        [SerializeField] private Weapon _cannon;
        [SerializeField] private Timer _cooldownTimer;

        private GameObject _target;

        private void Update()
        {
            if (CanAttack()) 
                Attack();
        }

        private void Attack()
        {
            _cannon.Attack(_target);
            _cooldownTimer.Play();
        }

        public override void SetTarget(GameObject target) =>
            _target = target;

        public override void ResetTarget() =>
            _target = null;

        private bool CanAttack() =>
            _target != null && _cooldownTimer.IsDone && _cannon.CanAttack();
    }
}