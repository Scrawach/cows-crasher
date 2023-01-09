using UnityEngine;

namespace CodeBase.Cow
{
    public class Mooing : MonoBehaviour
    {
        [SerializeField] private UfoAttractedBody _attractedBody;
        [SerializeField] private float _radius = 10f;
        [SerializeField] private float _cooldown;

        private float _elapsed;
        
        public bool Heard { get; private set; }

        private void Update()
        {
            UpdateCooldown();

            if (_attractedBody.IsAttracting && CooldownIsUp())
            {
                _elapsed = 0;
                Moo();
            }
        }

        public void Listen() =>
            Heard = true;

        public void Forget() =>
            Heard = false;

        private void Moo()
        {
            var listeners = Physics.OverlapSphere(transform.position, _radius);
            
            foreach (var listener in listeners)
            {
                if (listener.TryGetComponent(out Mooing mooing))
                    mooing.Listen();
            }
        }

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
                _elapsed += Time.deltaTime;
        }
        
        private bool CooldownIsUp() =>
            _elapsed >= _cooldown;
    }
}