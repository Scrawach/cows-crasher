using UnityEngine;

namespace CodeBase.Lifetime
{
    public class DestroyWhenOutOfScreen : MonoBehaviour
    {
        [SerializeField] private BecameInvisible _becameInvisible;

        private void OnEnable() =>
            _becameInvisible.OutOfScreen += OnOutOfScreen;

        private void OnDisable() =>
            _becameInvisible.OutOfScreen -= OnOutOfScreen;

        private void OnOutOfScreen() =>
            Destroy(gameObject);
    }
}