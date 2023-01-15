using UnityEngine;

namespace CodeBase.Utils
{
    [ExecuteInEditMode]
    public class RandomScaleInEditor : MonoBehaviour
    {
        [SerializeField] private Vector2 _range;
        private void Start()
        {
#if UNITY_EDITOR
            var scaleY = Random.Range(_range.x, _range.y);
            transform.localScale = new Vector3(1, scaleY, 1);
#endif
        }
    }
}