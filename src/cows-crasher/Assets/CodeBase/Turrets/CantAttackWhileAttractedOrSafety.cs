using CodeBase.AI.Components;
using UnityEngine;

namespace CodeBase.Turrets
{
    public class CantAttackWhileAttractedOrSafety : MonoBehaviour
    {
        [SerializeField] private AttackWithCooldown _attackComponent;
        [SerializeField] private Timer _cooldownTimer;
        [SerializeField] private Collider _body;
        [SerializeField] private UfoAttractedBody _ufoAttracted;

        private void Update() =>
            Switching();

        private void Switching()
        {
            switch (_attackComponent.enabled)
            {
                case true when _ufoAttracted.IsAttracting || !_body.enabled:
                    _attackComponent.enabled = false;
                    _cooldownTimer.Stop();
                    break;
                case false when !_ufoAttracted.IsAttracting && _body.enabled:
                    _attackComponent.enabled = true;
                    _cooldownTimer.Play();
                    break;
            }
        }
    }
}