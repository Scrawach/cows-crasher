using System;
using CodeBase.AI.Components;
using CodeBase.Audio;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.AI.Cow
{
    public class Mooing : MonoBehaviour
    {
        [SerializeField] private UfoAttractedBody _attractedBody;
        [SerializeField] private float _radius = 10f;
        [SerializeField] private float _cooldown;
        [SerializeField] private AudioPlayer _audio;

        private float _elapsed;
        private AudioPlayer _activeAudio;
        
        public bool Heard { get; private set; }

        public bool CanMoo => CooldownIsUp();

        private void Update()
        {
            UpdateCooldown();

            if (_attractedBody.IsAttracting && CanMoo)
            {
                _elapsed = 0;
                Moo();
            }
        }

        public void Listen()
        {
            Heard = true;
            _elapsed = 0;
        }

        public void Forget()
        {
            Heard = false;
            _elapsed = 0;
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

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
                _elapsed += Time.deltaTime;
        }
        
        private bool CooldownIsUp() =>
            _elapsed >= _cooldown;
    }
}