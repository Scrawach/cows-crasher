using UnityEngine;

namespace CodeBase.Logic.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        public abstract void Construct(Vector3 targetPosition);
    }
}