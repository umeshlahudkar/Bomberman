using UnityEngine;
using Bomberman.Global;
using Bomberman.PlayerService;
using Bomberman.SO;

namespace Bomberman.BombSrvice
{
    public class BombService : GenericSingleton<BombService>
    {
        [SerializeField] private BombSO bombSO;
        [SerializeField] private BombPooler bombPooler;

        public BombController GetBomb(Transform spawnPosition, PlayerController playerController)
        {
            BombController bombController = bombPooler.GetItem(bombSO, spawnPosition, playerController);
            bombController.Enable(spawnPosition.position);
            return bombController;
        }


    }
}
