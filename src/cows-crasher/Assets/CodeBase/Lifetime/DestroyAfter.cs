using UnityEngine;

namespace CodeBase.Lifetime
{
    public class DestroyAfter : MonoBehaviour
    {
        [SerializeField] private float _pauseInSeconds;

        private void Awake() => 
            Destroy(gameObject, _pauseInSeconds);
    }
}