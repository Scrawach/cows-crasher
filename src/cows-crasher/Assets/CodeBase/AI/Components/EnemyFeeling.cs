using UnityEngine;

namespace CodeBase.AI.Components
{
    public class EnemyFeeling : MonoBehaviour
    {
        [SerializeField] private Observer _enemyObserver;
        
        public Transform Enemy { get; private set; }

        private void OnEnable() => 
            _enemyObserver.Entered += OnFindEnemy;

        private void OnDisable() => 
            _enemyObserver.Entered -= OnFindEnemy;

        public bool FeelEnemy() => 
            Enemy != null;

        private void OnFindEnemy(GameObject enemy) => 
            Enemy = enemy.transform;
    }
}