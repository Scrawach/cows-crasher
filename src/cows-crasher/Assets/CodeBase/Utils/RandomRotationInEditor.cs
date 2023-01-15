using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Utils
{
    [ExecuteInEditMode]
    public class RandomRotationInEditor : MonoBehaviour
    {
        [SerializeField] private Vector2 _range;
        
        private void Start()
        {
#if UNITY_EDITOR
            var rotationY = Random.Range(_range.x, _range.y);
            transform.Rotate(0f, rotationY, 0f);
#endif
        }
    }
}