using UnityEngine;

namespace CodeBase.AI.Components
{
    public class EnemyFeeling : MonoBehaviour
    {
        [field: SerializeField] public Transform Enemy { get; private set; }
    }
}