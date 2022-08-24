using UnityEngine;
using Bomberman.SO;
using Bomberman.Global;
using Bomberman.PlayerService;

namespace Bomberman.BombSrvice
{
    public class BombPooler : ObjectPool<BombController>
    {
        private BombSO bombSO;
        private Transform spawnPosition;
        private PlayerController playerController;

        public BombController GetItem(BombSO bombSO, Transform spawnPosition, PlayerController playerController)
        {
            this.bombSO = bombSO;
            this.spawnPosition = spawnPosition;
            this.playerController = playerController;
            return GetItem();
        }

        protected override BombController CreateNew()
        {
            BombController bombController = new BombController(bombSO, spawnPosition, playerController);
            return bombController;
        }
    }
}
