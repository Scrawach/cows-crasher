using UnityEngine;

namespace CodeBase.Turrets
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract bool CanAttack();
        public abstract void Attack(GameObject target);
    }
}