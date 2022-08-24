using UnityEngine;
using Bomberman.BombSrvice;
using Bomberman.SO;
using Bomberman.EventSrvice;

namespace Bomberman.PlayerService
{
    public class PlayerController
    {
        public PlayerModel playerModel { get; private set; }
        public PlayerView playerView { get; private set; }
        private bool canPlaceBomb = true;
        private Vector3 direction;

        public PlayerController(PlayerSO playerSO, Vector3 spawnPosition)
        {
            playerModel = new PlayerModel(playerSO);
            playerView = GameObject.Instantiate<PlayerView>(playerSO.playerViewPrefab, spawnPosition, Quaternion.identity);

            playerView.SetPlayerController(this);
        }

        public void PlantBomb()
        {
            if (canPlaceBomb && Time.timeScale != 0)
            {
                BombService.Instance.GetBomb(playerView.transform, this);
                canPlaceBomb = false;
            }
        }

        public void Move(Rigidbody rb, float xInput, float yInput)
        {
            direction.x = xInput * playerModel.movementSpeed * Time.fixedDeltaTime;
            direction.z = yInput * playerModel.movementSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + direction);
        }

        public void Die()
        {
            EventService.Instance.InvokeOnGameOverEvent("Game Over");
        }

        public void SetCanPlaceBomb(bool status)
        {
            canPlaceBomb = status;
        }
    }
}

