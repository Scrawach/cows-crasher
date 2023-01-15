using CodeBase.AI.Components;
using CodeBase.AI.Cow;
using UnityEngine;

namespace CodeBase.Turrets
{
    public class CannonOperator : MonoBehaviour
    {
        [SerializeField] private Cannon _cannon;
        [SerializeField] private Collider _observerCollider;
        [SerializeField] private Timer _cooldownTimer;
        [SerializeField] private UfoAttractedBody _ufoAttractedBody;
        [SerializeField] private Collider _body;

        private bool _isActivated;

        private void Update() => 
            SwitchActivation();

        private void SwitchActivation()
        {
            switch (_isActivated)
            {
                case true when _ufoAttractedBody.IsAttracting || !_body.enabled:
                    Deactivate();
                    break;
                case false when !_ufoAttractedBody.IsAttracting && _body.enabled:
                    Activate();
                    break;
            }
        }

        private void Activate()
        {
            _observerCollider.enabled = true;
            _cannon.enabled = true;
            _cooldownTimer.Start();
            _isActivated = true;
        }

        private void Deactivate()
        {
            _observerCollider.enabled = false;
            _cannon.enabled = false;
            _cooldownTimer.Stop();
            _isActivated = false;
        }
    }
}