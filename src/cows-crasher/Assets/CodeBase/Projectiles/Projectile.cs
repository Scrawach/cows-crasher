using UnityEngine;

namespace CodeBase.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        public abstract void Construct(Vector3 targetPosition);
    }
}