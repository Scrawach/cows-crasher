using CodeBase.AI.Components;
using CodeBase.AI.Cow.Transitions.Abstract;
using UnityEngine;

namespace CodeBase.AI.Cow.Transitions
{
    public class IsEnemyFarAway : Transition
    {
        [SerializeField] private EnemyFeeling _enemyFeeling;
        [SerializeField] private float _distance;
        
        public override bool NeedTransit()
        {
            if (!_enemyFeeling.FeelEnemy())
                return false;

            var enemyPosition = _enemyFeeling.Enemy.position;
            var selfPosition = transform.position;
            enemyPosition.y = selfPosition.y;
            var distance = Vector3.Distance(selfPosition, enemyPosition);
            return distance > _distance;
        }
    }
}