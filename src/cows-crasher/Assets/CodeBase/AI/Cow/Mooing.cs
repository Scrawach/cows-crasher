using CodeBase.AI.Components;
using CodeBase.Audio;
using CodeBase.Common;
using UnityEngine;

namespace CodeBase.AI.Cow
{
    public class Mooing : MonoBehaviour
    {
        [SerializeField] private UfoAttractedBody _attractedBody;
        [SerializeField] private float _radius = 10f;
        [SerializeField] private Timer _cooldownTimer;
        [SerializeField] private AudioPlayer _audio;

        private AudioPlayer _activeAudio;
        
        public bool Heard { get; private set; }

        public bool CanMoo => _cooldownTimer.IsDone;

        private void Update()
        {
            if (_attractedBody.IsAttracting && CanMoo)
            {
                Moo();
                _cooldownTimer.Play();
            }
        }

        public void Listen()
        {
            Heard = true;
            _cooldownTimer.Play();
        }

        public void Forget()
        {
            Heard = false;
            _cooldownTimer.Play();
        }

        public void Moo()
        {
            PlaySound();

            var listeners = Physics.OverlapSphere(transform.position, _radius);
            
            foreach (var listener in listeners)
            {
                if (listener.TryGetComponent(out Mooing mooing))
                    mooing.Listen();
            }
        }

        private void PlaySound()
        {
            if (_activeAudio != null && _activeAudio.IsPlaying)
                return;

            _activeAudio = Instantiate(_audio, transform.position, Quaternion.identity);
            _activeAudio.Play();
        }
    }
}