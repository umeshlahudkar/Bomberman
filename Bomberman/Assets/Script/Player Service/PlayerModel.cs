using Bomberman.SO;

namespace Bomberman.PlayerService
{
    public class PlayerModel
    {
        public float movementSpeed { get; private set; }

        public PlayerModel(PlayerSO playerSO)
        {
            movementSpeed = playerSO.movementSpeed;
        }
    }
}
