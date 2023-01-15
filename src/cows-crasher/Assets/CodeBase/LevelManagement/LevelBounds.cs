using System.Linq;
using UnityEngine;

namespace CodeBase.LevelManagement
{
    public class LevelBounds : MonoBehaviour
    {
        [SerializeField] private Collider[] _bounds;

        public bool Has(Vector3 position)
        {
            position.y = 0;
            return _bounds.Any(bound => bound.bounds.Contains(position));
        }
    }
}