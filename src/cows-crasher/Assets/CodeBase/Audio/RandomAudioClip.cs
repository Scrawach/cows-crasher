using UnityEngine;

namespace CodeBase.Audio
{
    public class RandomAudioClip : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip[] _variants;

        private void Awake()
        {
            var index = Random.Range(0, _variants.Length);
            _source.clip = _variants[index];
        }
    }
}