using UnityEngine;

namespace CodeBase.Turrets
{
    public abstract class TargetHandler : MonoBehaviour
    {
        public abstract void SetTarget(GameObject target);
        public abstract void ResetTarget();
    }
}