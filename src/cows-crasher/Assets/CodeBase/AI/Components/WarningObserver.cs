using CodeBase.AI.Cow;
using UnityEngine;

namespace CodeBase.AI.Components
{
    public class WarningObserver : MonoBehaviour
    {
        [SerializeField] private Observer _observer;
        [SerializeField] private Mooing _mooing;

        private void OnEnable() => 
            _observer.Entered += OnTargetDetected;

        private void OnDisable() => 
            _observer.Entered -= OnTargetDetected;

        private void OnTargetDetected(GameObject target)
        {
            if (_mooing.CanMoo)
                _mooing.Moo();
        }
    }
}