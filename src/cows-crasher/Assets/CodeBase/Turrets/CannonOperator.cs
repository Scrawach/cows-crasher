using CodeBase.AI.Components;
using UnityEngine;

namespace CodeBase.Turrets
{
    public class CannonOperator : MonoBehaviour
    {
        [SerializeField] private Cannon _cannon;
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

        public void SetTarget(GameObject target) =>
            _target = target;

        private bool CanAttack() =>
            _target != null && _cooldownTimer.IsDone && _cannon.CanAttack();
    }
}