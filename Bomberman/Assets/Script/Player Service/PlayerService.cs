using UnityEngine;
using Bomberman.Global;
using Bomberman.SO;

namespace Bomberman.PlayerService
{
    public class PlayerService : GenericSingleton<PlayerService>
    {
        [SerializeField] private PlayerSO playerSO;
        [SerializeField] private Vector3 spwanPosition;

        private void Start()
        {
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            PlayerController playerController = new PlayerController(playerSO, spwanPosition);
        }
    }
}

