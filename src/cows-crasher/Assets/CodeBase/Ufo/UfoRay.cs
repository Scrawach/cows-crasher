using UnityEngine;

namespace CodeBase.Ufo
{
    public class UfoRay : MonoBehaviour
    {
        [SerializeField] private AntigravityZone _antigravity;
        [SerializeField] private MeshRenderer _rayRenderer;
        [SerializeField] private ParticleSystem _antigravityVfx;
        
        public bool IsActivated { get; private set; }

        public void ActivateRay()
        {
            _rayRenderer.enabled = true;
            _antigravity.Activate();
            _antigravityVfx.Play();
            IsActivated = true;
        }

        public void DeactivateRay()
        {
            _rayRenderer.enabled = false;
            _antigravity.Deactivate();
            _antigravityVfx.Stop();
            IsActivated = false;
        }
    }
}