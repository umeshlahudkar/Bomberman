using System.Collections.Generic;
using UnityEngine;
using Bomberman.Global;
using Bomberman.SO;
using Bomberman.EventSrvice;
using Bomberman.Grid;

namespace Bomberman.EnemyService
{
    public class EnemyService : GenericSingleton<EnemyService>
    {
        [SerializeField] private EnemySO enemySO;
        [SerializeField] private GridController gridController;
        [SerializeField] private EnemyPooler enemyPooler;
        [SerializeField] private int enemyCount;
        private List<EnemyController> activeEnemyControllers = new List<EnemyController>();

        private void Start()
        {
            CreateEnemy(enemyCount);
        }

        private void CreateEnemy(int count)
        {
            for (int i = 0; i < count; i++)
            {
                SpwanEnemy();
            }
        }

        private void SpwanEnemy()
        {
            Vector3 spawnPosition = gridController.GetEmptyPosition();
            if (spawnPosition != null)
            {
                EnemyController enemyController = enemyPooler.GetItem(enemySO, spawnPosition, this);
                activeEnemyControllers.Add(enemyController);
            }
        }

        public void RemoveDisableEnemy(EnemyController _enemyController)
        {
            EnemyController enemyController = activeEnemyControllers.Find(item => item.Equals(_enemyController));
            if (enemyController != null)
            {
                activeEnemyControllers.Remove(enemyController);
            }

            if (activeEnemyControllers.Count <= 2 && activeEnemyControllers.Count > 0)
            {
                for (int i = 0; i < activeEnemyControllers.Count; i++)
                {
                    activeEnemyControllers[i].SetCanAttack(false);
                }
            }
            else if (activeEnemyControllers.Count == 0)
            {
                EventService.Instance.InvokeOnGameWinEvent("You Won");
            }
        }
    }
}

