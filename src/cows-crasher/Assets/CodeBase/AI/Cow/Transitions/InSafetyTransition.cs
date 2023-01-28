using CodeBase.AI.Components;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.Transitions
{
    public class InSafetyTransition : Transition
    {
        [SerializeField] private EnemyFeeling _enemyFeeling;
        [SerializeField] private float _safetyDistance;

        public override bool NeedTransit()
        {
            if (!_enemyFeeling.FeelEnemy())
                return true;
            
            var target = _enemyFeeling.Enemy.position;
            target.y = 0;
            var distance = Vector3.Distance(transform.position, target);
            return distance >= _safetyDistance;
        }
    }
}