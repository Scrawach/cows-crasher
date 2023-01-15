using CodeBase.AI.Components;
using CodeBase.AI.Cow;
using CodeBase.Audio;
using CodeBase.Projectiles;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Turrets
{
    public class Catapult : MonoBehaviour
    {
        [SerializeField] private CatapultAnimator _animator;
        [SerializeField] private Observer _targetObserver;
        [SerializeField] private RotateToTarget _rotateToTarget;
        [SerializeField] private Timer _cooldown;
        [SerializeField] private float _attackAngle;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Projectile _projectile;
        [SerializeField] private AudioPlayer _attackSfx;

        private GameObject _target;
        private bool _isAttacking;
        private Vector3 _lastAttackPosition;

        private void Awake() =>
            _cooldown.Play();

        private void OnEnable()
        {
            _targetObserver.Entered += OnTargetFind;
            _targetObserver.Exited += OnTargetLost;
        }

        private void OnDisable()
        {
            _targetObserver.Entered -= OnTargetFind;
            _targetObserver.Exited -= OnTargetLost;

        }

        private void Update()
        {
            if (CanAttack()) 
                Attack(_target);
        }

        private bool CanAttack() =>
            HasTarget() && CooldownIsUp() && InAttackAngle() && WaitingForAttack();

        private void Attack(GameObject target)
        {
            _lastAttackPosition = target.transform.position;
            _isAttacking = true;
            _animator.StartAttack(OnAttackDone);
            Instantiate(_attackSfx, transform.position, Quaternion.identity);
        }

        private void OnAttackDone()
        {
            var projectileInstance = Instantiate(_projectile, _firePoint.position, Quaternion.identity);
            projectileInstance.Construct(_lastAttackPosition);
            _isAttacking = false;
            _cooldown.Play();
        }

        private bool InAttackAngle() =>
            _rotateToTarget.AngleToTarget <= _attackAngle;

        private bool WaitingForAttack() =>
            !_isAttacking;

        private bool CooldownIsUp() =>
            _cooldown.IsDone;

        private bool HasTarget() =>
            _target != null;

        private void OnTargetFind(GameObject target) =>
            _target = target;

        private void OnTargetLost(GameObject target) =>
            _target = null;
    }
}