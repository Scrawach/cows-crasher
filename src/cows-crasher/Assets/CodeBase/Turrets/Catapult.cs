using CodeBase.AI.Components;
using UnityEngine;

namespace CodeBase.Turrets
{
    public class Catapult : Weapon
    {
        [SerializeField] private Cannon _cannon;
        [SerializeField] private RotateToTarget _rotateToTarget;
        [SerializeField] private float _attackAngle;

        private GameObject _target;
        private bool _isAttacking;
        private Vector3 _lastAttackPosition;
        
        public override bool CanAttack() =>
            InAttackAngle() && _cannon.CanAttack();

        public override void Attack(GameObject target) =>
            _cannon.Attack(target);
        
        private bool InAttackAngle() =>
            _rotateToTarget.AngleToTarget <= _attackAngle;
    }
}