using UnityEngine;

namespace CodeBase.Projectiles.Abstract
{
    public abstract class Projectile : MonoBehaviour
    {
        public abstract void Construct(Vector3 targetPosition);
    }
}