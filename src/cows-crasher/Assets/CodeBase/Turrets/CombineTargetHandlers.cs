using UnityEngine;

namespace CodeBase.Turrets
{
    public class CombineTargetHandlers : TargetHandler
    {
        [SerializeField] private TargetHandler[] _handlers;
        
        public override void SetTarget(GameObject target)
        {
            foreach (var handler in _handlers) 
                handler.SetTarget(target);
        }

        public override void ResetTarget()
        {
            foreach (var handler in _handlers) 
                handler.ResetTarget();
        }
    }
}