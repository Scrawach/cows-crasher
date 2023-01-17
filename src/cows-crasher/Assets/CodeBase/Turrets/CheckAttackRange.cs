using CodeBase.AI.Components;
using UnityEngine;

namespace CodeBase.Turrets
{
    public class CheckAttackRange : MonoBehaviour
    {
        [SerializeField] private Observer _observer;
        [SerializeField] private CannonOperator _operator;

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

        private void OnEnteredToAttackRange(GameObject target)
        {
            _operator.SetTarget(target);
            _operator.enabled = true;
        }

        private void OnExitFromAttackRange(GameObject target) =>
            _operator.enabled = false;
    }
}