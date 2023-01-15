using UnityEngine;

namespace CodeBase.Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;

        public bool IsPlaying => _source.isPlaying;
        
        public void Play() => 
            _source.Play();
    }
}