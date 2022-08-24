using UnityEngine;
using Bomberman.Global;
using Bomberman.SO;

namespace Bomberman.EnemyService
{
    public class EnemyPooler : ObjectPool<EnemyController>
    {
        private EnemySO enemySO;
        private Vector3 spawnPosition;
        private EnemyService enemyService;

        public EnemyController GetItem(EnemySO enemySO, Vector3 spawnPosition, EnemyService enemyService)
        {
            this.enemySO = enemySO;
            this.spawnPosition = spawnPosition;
            this.enemyService = enemyService;
            return GetItem();
        }

        protected override EnemyController CreateNew()
        {
            EnemyController enemyController = new EnemyController(enemySO, spawnPosition, enemyService);
            return enemyController;
        }
    }
}
