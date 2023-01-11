using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Ufo
{
    public class UfoRay : MonoBehaviour
    {
        [SerializeField] private AntigravityZone _antigravity;
        [SerializeField] private MeshRenderer _rayRenderer;
        [SerializeField] private ParticleSystem _antigravityVfx;
        
        private PlayerInput _input;
        
        public bool IsActivated { get; private set; }

        private void Awake() =>
            _input = new PlayerInput(Camera.main);

        private void Update()
        {
            if (_input.IsInteractButtonPressed() && !IsActivated)
                ActivateRay();
            else if (_input.IsInteractButtonPressed() && IsActivated)
                DeactivateRay();
        }

        private void ActivateRay()
        {
            _rayRenderer.enabled = true;
            _antigravity.Activate();
            _antigravityVfx.Play();
            IsActivated = true;
        }

        private void DeactivateRay()
        {
            _rayRenderer.enabled = false;
            _antigravity.Deactivate();
            _antigravityVfx.Stop();
            IsActivated = false;
        }
    }
}