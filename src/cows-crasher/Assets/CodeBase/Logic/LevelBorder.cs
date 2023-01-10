using UnityEngine;

namespace CodeBase.Logic
{
    public class LevelBorder : MonoBehaviour
    {
        [field: SerializeField] public Rect Rect { get; private set; }

        private void OnDrawGizmos() =>
            DrawGizmosRect(Rect);

        private static void DrawGizmosRect(Rect rect) =>
            Gizmos.DrawWireCube(new Vector3(rect.center.x, 0.01f, rect.center.y), new Vector3(rect.size.x, 0.01f, rect.size.y));
    }
}