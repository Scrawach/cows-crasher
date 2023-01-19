using CodeBase.AI.Components;
using CodeBase.Common;
using UnityEngine;

namespace CodeBase.Turrets
{
    public class CatapultOperator : MonoBehaviour
    {
        [SerializeField] private Animator _catapultAnimator;
        [SerializeField] private Observer _observer;
        [SerializeField] private Timer _cooldownTimer;
        [SerializeField] private TargetHandler _targetHandler;

        public void Activate()
        {
            _catapultAnimator.enabled = true;
            _observer.gameObject.SetActive(true);
            _cooldownTimer.Resume();
        }

        public void Deactivate()
        {
            _catapultAnimator.enabled = false;
            _observer.gameObject.SetActive(false);
            _cooldownTimer.Pause();
            _targetHandler.ResetTarget();
        }
    }
}