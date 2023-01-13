using UnityEngine;

namespace CodeBase.Logic
{
    public class RandomPitch : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private Vector2 _range;

        private void Awake() => 
            _source.pitch = Random.Range(_range.x, _range.y);
    }
}