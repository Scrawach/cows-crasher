using UnityEngine;

namespace CodeBase.Audio
{
    public class DestroyAfterPlaying : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;

        private void Update()
        {
            if (!_source.isPlaying)
                Destroy(gameObject);
        }
    }
}