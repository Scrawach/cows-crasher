using CodeBase.AI.Components;
using UnityEngine;

namespace CodeBase.Turrets
{
    public class CheckAttackRange : MonoBehaviour
    {
        [SerializeField] private Observer _observer;
        [SerializeField] private TargetHandler _handler;

        private void OnEnable()
        {
            _observer.Entered += OnEnteredToAttackRange;
            _observer.Exited += OnExitFromAttackRange;
        }

        private void OnDisable()
        {
            _observer.Entered -= OnEnteredToAttackRange;
            _observer.Exited -= OnExitFromAttackRange;
        }

        private void OnEnteredToAttackRange(GameObject target) =>
            _handler.SetTarget(target);

        private void OnExitFromAttackRange(GameObject target) =>
            _handler.ResetTarget();
    }
}