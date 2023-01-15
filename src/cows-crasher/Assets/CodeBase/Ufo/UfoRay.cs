using UnityEngine;

namespace CodeBase.Ufo
{
    public class UfoRay : MonoBehaviour
    {
        [SerializeField] private AntigravityZone _antigravity;
        [SerializeField] private MeshRenderer _rayRenderer;
        [SerializeField] private ParticleSystem _antigravityVfx;
        [SerializeField] private AudioSource _activateSfx;
        
        public bool IsActivated { get; private set; }

        public void ActivateRay()
        {
            if (IsActivated)
                return;
            
            _rayRenderer.enabled = true;
            _antigravity.Activate();
            _antigravityVfx.Play();
            IsActivated = true;
            _activateSfx.Play();
        }

        public void DeactivateRay()
        {
            if (!IsActivated)
                return;
            
            _rayRenderer.enabled = false;
            _antigravity.Deactivate();
            _antigravityVfx.Stop();
            IsActivated = false;
        }
    }
}